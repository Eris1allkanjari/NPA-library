<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeFile="return_books.aspx.cs" Inherits="librarian_return_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
     <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Return Books</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid" style="min-height:500px; background-color:white">
        <br /><br />
        <asp:DataList ID="d1" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered">
                    <tr>
                        <th>Enrollment number</th>
                         <th>Book ISBN</th>
                         <th>Issue date</th>
                         <th>Return date</th>
                         <th>Student username</th>
                         <th>Is book returned</th>
                         <th>Returned date</th>
                         <th>Latedays</th>
                        <th>Penalty ($)</th>
                        <th>Return Books</th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>

                <tr>
                    <td><%#Eval("student_enrollment_no") %></td>
                    <td><%#Eval("books_isbn") %></td>
                    <td><%#Eval("books_issue_date") %></td>
                    <td><%#Eval("books_approx_return_date") %></td>
                    <td><%#Eval("student_username") %></td>
                    <td><%#Eval("is_books_return") %></td>
                    <td><%#Eval("books_returned_date") %></td>
                    <td><%#Eval("latedays") %></td>
                    <td><%#Eval("penalty") %></td>
                    <td><a href="returnbook.aspx?id=<%#Eval("id") %>">Return Books</a></td>
                </tr>


            </ItemTemplate>
            
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
      
    </div>

</asp:Content>

