<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Workshops.Models.Workshop>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <% if(Model.Count()==0)
       { %>
       <div>GEEN ELEMENTEN</div>
    <% } %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Title
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id= item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Title %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

