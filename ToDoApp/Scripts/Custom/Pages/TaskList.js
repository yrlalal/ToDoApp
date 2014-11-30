var taskList;
var tableHead;

$(document).ready(function () {
	todoApp.getAllTasks();
});

todoApp.getAllTasks = function () {
	$.ajax({
		url: "/Task/ListDetails",
		async: false,
		type: "GET",
		contentType: "application/json; charset=utf-8",
		dataType: "JSON",
		success: function (result) {
			taskList = result.TaskList;
			todoApp.buildTable();
		},
		error: function () {
			taskList = null;
			$(".task-list").html("");
			$(".task-list").text("Error occured while loading the table.");
		}
	});
};

todoApp.buildTable = function () {
	tableHead = $("#all-tasks").find("tr:first");
	$("#all-tasks").find("tr:gt(0)").remove();
	$.each(taskList, function (i, item) {
		var tr = document.createElement("tr");

		var td = document.createElement("td");
		td.setAttribute("class", "col-description");

		var span = document.createElement("span");
		span.textContent = item.Description;
		td.appendChild(span);
		tr.appendChild(td);

		td = document.createElement("td");
		td.setAttribute("class", "col-category");
		span = document.createElement("span");
		span.textContent = item.Category;
		td.appendChild(span);
		tr.appendChild(td);

		td = document.createElement("td");
		td.setAttribute("class", "col-duedate");
		span = document.createElement("span");
		span.textContent = item.DueDate;
		td.appendChild(span);
		tr.appendChild(td);

		td = document.createElement("td");
		td.setAttribute("class", "col-status");
		span = document.createElement("span");
		span.textContent = item.Status;
		td.appendChild(span);
		tr.appendChild(td);

		td = document.createElement("td");
		td.setAttribute("class", "col-priority");
		span = document.createElement("span");
		span.textContent = item.Priority;
		td.appendChild(span);
		tr.appendChild(td);

		td = document.createElement("td");
		td.setAttribute("class", "col-actions");
		var anchorTag = document.createElement("a");
		anchorTag.setAttribute("href", "/Task/Edit/" + item.Id);
		anchorTag.textContent = "Edit";
		td.appendChild(anchorTag);

		span = document.createElement("span");
		span.textContent = " | ";
		td.appendChild(span);

		anchorTag = document.createElement("a");
		anchorTag.setAttribute("href", "/Task/Delete/" + item.Id);
		anchorTag.textContent = "Delete";
		td.appendChild(anchorTag);

		tr.appendChild(td);

		$("#all-tasks tr:last").after(tr);
	});
};

todoApp.groupByDueDate = function () {
	if (taskList != null) {
		taskList = taskList.sort(todoApp.sortByDueDate);
		todoApp.buildTable();
	}
};

todoApp.sortByDueDate = function(obj1, obj2) {
	return (obj1.DueDate < obj2.DueDate) ? -1 : (obj1.DueDate > obj2.DueDate) ? 1 : 0;
};

todoApp.groupByPriority = function () {
	if (taskList != null) {
		taskList.sort(todoApp.sortByPriority);
		todoApp.buildTable();
	}
};

todoApp.sortByPriority = function (obj1, obj2) {
	return (obj1.Priority < obj2.Priority) ? -1 : (obj1.Priority > obj2.Priority) ? 1 : 0;
};

todoApp.groupByStatus = function () {
	if (taskList != null) {
		taskList.sort(todoApp.sortByStatus);
		todoApp.buildTable();
	}
};

todoApp.sortByStatus = function (obj1, obj2) {
	return (obj1.Status < obj2.Status) ? -1 : (obj1.Status > obj2.Status) ? 1 : 0;
};

todoApp.groupByCategory = function () {
	if (taskList != null) {
		taskList.sort(todoApp.sortByCategory);
		todoApp.buildTable();
	}
};

todoApp.sortByCategory = function (obj1, obj2) {
	return (obj1.Category < obj2.Category) ? -1 : (obj1.Category > obj2.Category) ? 1 : 0;
};