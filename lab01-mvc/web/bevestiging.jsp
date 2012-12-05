<%-- 
    Document   : bevestiging
    Created on : Oct 2, 2012, 5:21:47 PM
    Author     : Ah Lun Tang
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="f"%> 

<h2>Concertereservatie voor ${concert.titel}: bevestig!</h2>

<div class="alert alert-block">
    <button type="button" class="close" data-dismiss="alert">×</button>
    <h4>Opgelet!</h4>
    Controleer nog eens je bestelling voordat je bevestigt.
</div>
<dl class="dl-horizontal">
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

<div class="form-horizontal">
    <div class="control-group">
        <div class="controls">
            <form action="reservatie.do" method="GET">
                <input type="hidden" name="concertid" value="${concertid}" />
                <input type="hidden" id="aantalnormaal" name="aantalnormaal" value="<c:out value="${aantalnormaal}"/>" />
                <input type="hidden" id="aantalreductie" name="aantalreductie" value="<c:out value="${aantalreductie}"/>" />
                <input type="hidden" id="naam" name="naam" value="<c:out value="${naam}"/>" />
                <button type="submit" class="btn btn-primary">Wijzig</button>
            </form><form action="besteld.do" method="GET">
                <input type="hidden" name="concertid" value="${concertid}" />
                <input type="hidden" id="aantalnormaal" name="aantalnormaal" value="<c:out value="${aantalnormaal}"/>" />
                <input type="hidden" id="aantalreductie" name="aantalreductie" value="<c:out value="${aantalreductie}"/>" />
                <input type="hidden" id="naam" name="naam" value="<c:out value="${naam}"/>" />
                <button type="submit" class="btn btn-success">Bevestig en bestel!</button>
            </form>
        </div>
    </div>
</div>