<%-- 
    Document   : concerten
    Created on : Oct 2, 2012, 2:57:25 PM
    Author     : Ah Lun Tang
--%>

<%@page contentType="text/html"%>
<%@page pageEncoding="UTF-8"%>
<%@page import="web.InitListener"%>
<%--
The taglib directive below imports the JSTL library. If you uncomment it,
you must also add the JSTL library to the project. The Add Library... action
on Libraries node in Projects view can be used to add the JSTL 1.1 library.
--%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
    <h2>Kies een concert</h2>
    <ul>
    <c:forEach var="concert" items="${concerten.alleConcerten}">
    <li><a href="<c:url value="reservatie.do">
        <c:param name="concertid" value="${concert.key}"/>
        </c:url>">${concert.value.titel}</a></li>
    </c:forEach>
    </ul>