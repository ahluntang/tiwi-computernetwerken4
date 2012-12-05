<%-- 
    Document   : concert.jsp
    Created on : Oct 2, 2012, 4:24:05 PM
    Author     : Ah Lun Tang
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="f"%> 

<h2>Concertreservatie: ${concert.titel}</h2>
<c:if test="${foutberichten != null}">
   <div class="alert alert-error">
       <ul>
           <c:forEach var="bericht" items="${foutberichten}"><li>${bericht}</li></c:forEach>
       </ul>
   </div>
</c:if>
<form class="form-horizontal" action="naarBevestiging.do" method="GET">
    <input type="hidden" name="concertid" value="${concertid}" />
    <div class="control-group">
        <label class="control-label" for="naam">Naam en voornaam:</label>
        <div class="controls">
            <input type="text" id="naam" name="naam" value="${naam}" placeholder="Naam en voornaam">
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="aantalnormaal">Normaal ticket: &euro; ${concert.prijsNormaal}</label>
        <div class="controls">
            <input type="text" id="aantalnormaal" name="aantalnormaal" value="${aantalnormaal}" placeholder="0">
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="aantalreductie">Reductie ticket: &euro; ${concert.prijsReductie}</label>
        <div class="controls">
            <input type="text" id="aantalreductie" name="aantalreductie" value="${aantalreductie}" placeholder="0">
        </div>
    </div>
    <div class="control-group">
        <div class="controls">
          <button type="submit" class="btn btn-primary">Reserveer</button>
        </div>
    </div>
         
</form>