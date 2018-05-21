<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PopularMovies.Default" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="popularMoviesWeek" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:ListView ID="movieList" runat="server" ItemType="PopularMovies.Models.Movie" DataKeyNames="Id" 
                SelectMethod="movieList_GetData">

                <ItemTemplate>
                    <tr>
                        <td><%# Item.Title%></td>
                        <td><%# Item.Directors %></td>
                        <td><%# Item.Genres %></td>
                        <td><%# Item.ReleaseDate.ToShortDateString() %></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table border="0" cellpadding="1" runat="server">                      
                        <tr style="background-color: #E5E5FE">
                            <th>Title</th>
                            <th>Directors</th>
                            <th>Genres</th>                                
                            <th>ReleaseDate</th>                                
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
