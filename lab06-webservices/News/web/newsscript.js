const URL = "http://localhost:8084/NewsOpgave/rest/"

if (typeof jQuery == 'undefined') {
	log("jQuery not loaded!");
}

$(document).ready(function()
{
	$("#submitButton")
		.click( function() {
			postNewsItem();
		});

	loadNewsItems();
});

function log(msg)
{
	if (window.console) {
		console.log(msg);
	}
}

function getXHR()
{
	return window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject('Microsoft.XMLHTTP');
}

function makeParamString(params)
{
	if (params)
	{
		var str = [];
		for (var p in params)
			str.push(encodeURIComponent(p) + "=" + encodeURIComponent(params[p]));
		return str.join("&");
	}
	else
		return "";
}

function ajaxGet(url, params, readyfunc) // url can be unencoded, readyfunc takes xhr-param
{
	var xhr = getXHR();
	if (readyfunc)
		xhr.onreadystatechange=function() {
			if (xhr.readyState==4 && xhr.status>=200 && xhr.status<=300)
				readyfunc(xhr);
		}
	if (params)
		url = url + "?" + makeParamString(params);
	log("ajax:getting " + url);
	xhr.open("GET", url, true);
	xhr.send();
}

function ajaxPost(url, obj, readyfunc)
{
	var xhr = getXHR();
	if (readyfunc)
		xhr.onreadystatechange=function() {
			if (xhr.readyState==4 && xhr.status>=200 && xhr.status<=300)
				readyfunc(xhr);
		}
	log("ajax:posting " + url + " object:" + JSON.stringify(obj));
	xhr.open("POST", url, true);
	xhr.setRequestHeader("Content-type", "application/json");
	xhr.send(JSON.stringify(obj));
}

function ajaxPut(url, obj, readyfunc) // url can be unencoded, readyfunc takes xhr-param
{
	log("ajax put" + obj)
	var xhr = getXHR();
	if (readyfunc)
		xhr.onreadystatechange=function() {
			if (xhr.readyState==4 && xhr.status>=200 && xhr.status<=300)
				readyfunc(xhr);
		}
	log("ajax:putting " + url + " object:" + JSON.stringify(obj));
	xhr.open("PUT", url, true);
	xhr.setRequestHeader("Content-type", "application/json");
	xhr.send(JSON.stringify(obj));
}

function ajaxDelete(url, readyfunc) // url can be unencoded, readyfunc takes xhr-param
{
	var xhr = getXHR();
	if (readyfunc)
		xhr.onreadystatechange=function() {
			if (xhr.readyState==4 && xhr.status>=200 && xhr.status<=300)
				readyfunc(xhr);
		}
	log("ajax:deleting " + url);
	xhr.open("DELETE", url, true);
	xhr.send();
}


function createNewsItemElement(item)
{
	var div = $("<div>").attr("id", "entry" + item.id);

	$("<span>")
		.attr("id", "title" + item.id)
		.html(item.title)
		.appendTo(div);

	$("<input>")
		.attr("type", "button")
		.attr("id", "toggle" + item.id)
		.attr("value", "+")
		.click( function() {
			toggleDetails(item.id);
		})
		.appendTo(div);

	$("<div>")
		.attr("id", "details" + item.id)
		.appendTo(div);

	return div;
}


function loadNewsItems()
{
	var listNode = $("#entries").empty();

	ajaxGet(URL, null, function(xhr) {
		var items = JSON.parse(xhr.responseText);
		for (var i=0, len=items.length; i < len; i++)
		{
			log("loaded " + items[i].id + ": " + items[i].title);
			var itemNode = createNewsItemElement(items[i]);
			listNode.append(itemNode); // TODO: prepend
		}
	});
}


function toggleDetails(eid)
{
	log("toggling " + eid)
	//var el = $("#entry" + eid);
	var input = $("#toggle" + eid);
	if (input.val() === '+')
	{
		input.val('-');
		//input.style.display = 'none';
		loadNewsItemDetails(eid);
	}
	else
	{
		input.val('+');
		//input.style.di,splay = '';
		$("#details" + eid).empty();
	}
}


function loadNewsItemDetails(eid)
{
	log("loading details " + eid);
	var detailsNode = $("#details" + eid).empty();

	ajaxGet(URL + eid, null, function(xhr) {
		log("loading details ok");
		var item = JSON.parse(xhr.responseText);

		detailsNode.append( createDetailsElement(eid, item) );
	});
}

function createDetailsElement(eid, item)
{
	return $("<table>")
		.append( $("<tr>")
			.append($("<td>")
				.html("Date:")
			)
			.append( $("<td>")
				.html(item.date)
			)
		)
		.append( $("<tr>")
			.append($("<td>")
				.html("Author:")
			)
			.append( $("<td>")
				.append($("<input>")
					.attr("id", "authorTF" + eid)
					.attr("type", "text")
					.attr("value", item.author)
					.css("border", "none")
					.attr("disabled", "true")
				)
			)
		)
		.append( $("<tr>")
			.append($("<td>")
				.html("Title:")
			)
			.append( $("<td>")
				.append( $("<input>")
					.attr("id", "titleTF" + eid)
					.attr("type", "text")
					.attr("value", item.title)
					.css("border", "none")
					.attr("disabled", "true")
				)
			)
		)
		.append( $("<tr>")
			.append($("<td>")
				.html("Message:")
			)
			.append( $("<td>")
				.append( $("<input>")
					.attr("id", "messageTF" + eid)
					.attr("type", "text")
					.attr("size", 100)
					.attr("value", item.message)
					.css("border", "none")
					.attr("disabled", "true")
				)
			)
		)
		.append( $("<tr>")
			.append( $("<td>"))
			.append( $("<td>")
				.append ($("<input>")
					.attr("id", "remove" + eid)
					.attr("type", "button")
					.attr("value", "Remove")
					.click( function() {
						removeNewsItem(eid);
					} )
				)
				.append(  $("<input>")
					.attr("id", "edit" + eid)
					.attr("type", "button")
					.attr("value", "Edit")
					.click( function() {
						editNewsItem(eid);
					} )
				)
				.append(  $("<input>")
					.attr("id", "apply" + eid)
					.attr("type", "button")
					.attr("value", "Apply")
					.css("display", "none")
					.click( function() {
						applyEdit(eid);
					} )
				)
				.append(  $("<input>")
					.attr("id", "cancel" + eid)
					.attr("type", "button")
					.css("display", "none")
					.attr("value", "Cancel")
					.click( function() {
						cancelEdit(eid);
					} )
				)
			)
		);
}

function removeNewsItem(eid)
{
	ajaxDelete(URL + eid, function(xhr) {
		loadNewsItems();
	} );
}

function postNewsItem()
{
	var author = $("#newEntry #authorTF").val();
	var title = $("#newEntry #titleTF").val();
	var message = $("#newEntry #messageTF").val();

	log("sending " + author + ", " + title + ", " + message);
	ajaxPost(URL,
			 {'author':author, 'title':title, 'message':message},
			 function(xhr) {
				loadNewsItems();
			 } );

	$("#authorTF, #titleTF, #messageTF", "#newEntry").val("");
}

function editNewsItem(eid)
{
	$("#authorTF" + eid + ", #titleTF" + eid + ", #messageTF" + eid)
		.removeAttr("disabled")
		.css("border", "");

	$("#edit" + eid).css("display", "none");
	$("#apply" + eid).css("display", "");
	$("#cancel" + eid).css("display", "");
}

function applyEdit(eid)
{
	log("applying " + eid);
	var author = $("#authorTF" + eid).val();
	var title = $("#titleTF" + eid).val();
	var message = $("#messageTF" + eid).val();

	ajaxPut(URL + eid, {'author': author, 'title': title, 'message': message},
		function() {
			$("#title" + eid).html(message);
			loadNewsItemDetails(eid);
		} );
}

function cancelEdit(eid)
{
	log("canceling " + eid);
	loadNewsItemDetails(eid);
}
