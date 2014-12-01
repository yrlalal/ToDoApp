var taskList;

$(document).ready(function () {
	todoApp.getAllTasks();
});

todoApp.getAllTasks = function () {
	$.ajax({
		url: "/Task/ListDetails",
		type: "GET",
		async: false,
		cache: false,
		contentType: "application/json; charset=utf-8",
		dataType: "JSON",
		success: function (result) {
			taskList = result.TaskList;
			todoApp.populateTaskList(taskList);
		},
		error: function () {
			taskList = null;
			$(".task-list").html("");
			$("#loadingMessage").text("We are sorry. The loading of tasks failed. Please try again.");
		}
	});
};

todoApp.populateTaskList = function (list) {
	todoApp.prePopulate();
	todoApp.populateTable(list);
	todoApp.postPopulate();
};

todoApp.prePopulate = function () {
	$(".task-list").html("");
	$("#loadingMessage").removeClass("hidden");
	$(".add-task").addClass("hidden");
};

todoApp.populateTable = function (list) {
	var tableDiv = document.createElement("div");
	tableDiv.setAttribute("class", "table");

	var table = document.createElement("table");
	todoApp.addTableHeader(table);
	$.each(list, function (i, item) {
		todoApp.addTableRow(table, item);
	});

	tableDiv.appendChild(table);
	$(".task-list").append(tableDiv);
};

todoApp.postPopulate = function () {
	$("#loadingMessage").addClass("hidden");
	$(".add-task").removeClass("hidden");
};

todoApp.addTableHeader = function (table) {
	var tr = document.createElement("tr");
	todoApp.addTableHeaderCell(tr, "col-description", "Description");
	todoApp.addTableHeaderCell(tr, "col-category", "Category");
	todoApp.addTableHeaderCell(tr, "col-duedate", "Due Date");
	todoApp.addTableHeaderCell(tr, "col-status", "Status");
	todoApp.addTableHeaderCell(tr, "col-priority", "Priority");
	todoApp.addTableHeaderCell(tr, "col-actions", "Actions");
	table.appendChild(tr);
};

todoApp.addTableHeaderCell = function (tr, className, content) {
	var td = document.createElement("td");
	td.setAttribute("class", className);
	td.textContent = content;
	tr.appendChild(td);
};

todoApp.addTableRow = function (table, item) {
	var tr = document.createElement("tr");
	todoApp.addTableDataCell(tr, "col-description", item.Description);
	todoApp.addTableDataCell(tr, "col-category", item.Category);
	todoApp.addTableDataCell(tr, "col-duedate", item.DueDateDisplayString);
	todoApp.addTableDataCell(tr, "col-status", item.Status);
	todoApp.addTableDataCell(tr, "col-priority", item.Priority);
	todoApp.addTableActionsCell(tr, item.Id);
	todoApp.highlightTodaysTask(tr, item.IsDueToday, "due-today");
	table.appendChild(tr);
};

todoApp.addTableDataCell = function (tr, className, content) {
	var td = document.createElement("td");
	td.setAttribute("class", className);
	var span = document.createElement("span");
	span.textContent = content;
	td.appendChild(span);
	tr.appendChild(td);
};

todoApp.addTableActionsCell = function (tr, id) {
	var td = document.createElement("td");
	td.setAttribute("class", "col-actions");
	var anchorTag = document.createElement("a");
	anchorTag.setAttribute("href", "/Task/Edit/" + id);
	anchorTag.textContent = "Edit";
	td.appendChild(anchorTag);
	var span = document.createElement("span");
	span.textContent = " | ";
	td.appendChild(span);
	anchorTag = document.createElement("a");
	anchorTag.setAttribute("href", "/Task/Delete/" + id);
	anchorTag.textContent = "Delete";
	td.appendChild(anchorTag);
	tr.appendChild(td);
};

todoApp.highlightTodaysTask = function (tr, isDueToday, className) {
	if (isDueToday)
		tr.setAttribute("class", className);
};

todoApp.groupTasks = function (displayFieldName, sortFieldName, ascending) {
	var fieldValue;
	var list = [];
	var tempTaskList = taskList.slice(0);
	if (tempTaskList != null) {
		tempTaskList.sort(function (task1, task2) {
			return task1[sortFieldName] == task2[sortFieldName] ? 0 :
						task1[sortFieldName] == "" || task1[sortFieldName] == null ? 1 :
							task2[sortFieldName] == "" || task2[sortFieldName] == null ? -1 :
								ascending ? (task1[sortFieldName] < task2[sortFieldName] ? -1 : 1) :
																(task1[sortFieldName] < task2[sortFieldName] ? 1 : -1);
		});
	}
	todoApp.prePopulate();
	$.each(tempTaskList, function (i, item) {
		if (fieldValue != item[displayFieldName]) {
			if (list.length != 0) {
				todoApp.populateGroupTaskTable(fieldValue, list);
			}
			list = [];
			fieldValue = item[displayFieldName];
		}
		list.push(item);
	});
	if (list.length != 0) {
		todoApp.populateGroupTaskTable(fieldValue, list);
	}
	todoApp.postPopulate();
};

todoApp.populateGroupTaskTable = function (fieldValue, list) {
	var subHeader = document.createElement("h4");
	fieldValue === "" ? subHeader.textContent = "Unlisted" : subHeader.textContent = fieldValue;
	$(".task-list").append(subHeader);
	todoApp.populateTable(list);
};

todoApp.filterByDate = function (dueDate) {
	var list = [];
	$.each(taskList, function (i, item) {
		if (item.DueDateDisplayString === dueDate)
			list.push(item);
	});
	todoApp.populateTaskList(list);
};

todoApp.buildTaskTable = function () {
	todoApp.populateTaskList(taskList);
};
