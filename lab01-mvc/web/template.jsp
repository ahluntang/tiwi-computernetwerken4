<%-- 
    Document   : template
    Created on : Oct 2, 2012, 4:05:56 PM
    Author     : Ah Lun Tang
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Concerten Applicatie</title>
        <!-- Bootstrap -->
        <link href="css/bootstrap.min.css" rel="stylesheet">
    </head>
    <body>
        <jsp:include page="hoofding.jspf"/>
        
        <div class="container">
            <div class="hero-unit">
                <jsp:include page="${view}"/>
            </div>
        <hr>
        <footer>
            <p>Model View Controller Applicatie</p>
        </footer>
        </div>
        <script src="http://code.jquery.com/jquery-latest.js"></script>
        <script src="js/bootstrap.min.js"></script>
    </body>
</html>
