<%@ Page Title="" Language="C#" MasterPageFile="~/perdorues/perdorues.Master" AutoEventWireup="true" CodeFile="LibratEMi.aspx.cs" Inherits="student_my_issued_books" %>

<%@ MasterType VirtualPath="~/perdorues/perdorues.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <form id="hiqShporteForm" runat="server">

        <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>My Issued Books</h1>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid" style="min-height: 500px; background-color: white">
            <asp:DataList ID="d1" runat="server">
                <HeaderTemplate>
                    <table class="table" id="example">
                        <thead>
                            <tr>
                                <th scope="col"></th>
                                <th scope="col">Titulli</th>
                                <th scope="col">Autori</th>
                                <!-- <th scope="col">isbn</th>
                                    <th scope="col">available qty</th> -->
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="<%#Eval("book_image") %>" height="100" width="100" /></td>
                        <td><%#Eval("book_title") %></td>
                        <td><%#Eval("author_name") %></td>
                        <!-- <td><%//#Eval("books_isbn") %></td> -->
                        <td>
                            <asp:Button ID="hiqShportaBtn" CssClass="btn btn-primary" Text="Hiq nga shporte" CommandArgument='<%#Eval("books_isbn")%>' OnClick="hiqShportaBtn_Click" runat="server"></asp:Button></td>
                    </tr>

                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>

        </div>
    </form>



</asp:Content>

