﻿<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeFile="GjitheLibrat.aspx.cs" Inherits="librarian_display_all_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">

  <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">All Books</strong>
            </div>
            <div class="card-body">

                <asp:Repeater ID="r1" runat="server">
                    <HeaderTemplate>
                        <table class="table" id="example">
                            <thead>
                                <tr>
                                    <th scope="col">Book Cover</th>
                                    <th scope="col">Book Title</th>
                                    <th scope="col">Author Name</th>
                                    <th scope="col">ISBN</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Edit Books</th>
                                    <th scope="col">Delete Books</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><img src="<%#Eval("books_image") %>" height="100" width="100" /></td>
                            <td><%#Eval("books_title") %></td></td>
                            <td><%#Eval("books_author_name") %></td>
                            <td><%#Eval("books_isbn") %></td>
                            <td><%#Eval("available_qty") %></td>
                            <td><a href="edit_books.aspx?id=<%#Eval("id") %>">Edit Books</a></td>
                            <td><a href="delete_files.aspx?id2=<%#Eval("id") %>">Delete Books</a></td>
                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                       </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>


  <script type="text/javascript">
        $(document).ready(function() {
    $('#example').DataTable( {
        "pagingType": "full_numbers"
    } );
} );
    </script>

</asp:Content>
