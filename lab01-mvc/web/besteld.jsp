<%-- 
    Document   : besteld.jsp
    Created on : Oct 2, 2012, 10:15:26 PM
    Author     : ahluntang
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="f"%> 

<h2>Concertereservatie voor ${concert.titel}: besteld!</h2>

<div class="alert alert-success">
  <button type="button" class="close" data-dismiss="alert">×</button>
    <h4>Bedankt!</h4>
    Bestelling is verwerkt!
</div>
<h2>Bestelinformatie:</h2>
<dl class="dl-horizontal">
    <dt>Concert</dt>
    <dd><c:out value="${concert.titel}"/></dd>
    <dt>Naam en voornaam</dt>
    <dd><c:out value="${naam}"/></dd>
    <dt>Aantal normale tickets</dt>
    <dd><c:out value="${aantalnormaal}"/></dd>
    <dt>Aantal reductie tickets</dt>
    <dd><c:out value="${aantalreductie}"/></dd>
    <dt>Prijs</dt>
    <dd>
        <span class="label label-success">&euro; ${prijs}</span>
    </dd>
</dl>