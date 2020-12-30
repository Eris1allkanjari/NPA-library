﻿<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeFile="issue_books.aspx.cs" Inherits="librarian_issue_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">

    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Issue Books</strong>
            </div>
            <div class="card-body">
                <!-- Credit Card -->
                <div id="pay-invoice">
                    <div class="card-body">

                        

                        <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Select enrollment No</label>
                                <asp:DropDownList ID="enrno" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books isbn</label>
                               <asp:DropDownList ID="isbn" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="isbn_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                             <div class="form-group">
                                <asp:Image ID="i1" runat="server" Height="150" Width="150" Visible="false" /><br />
                                 <asp:Label ID="booksname" runat="server"></asp:Label><br />
                                 <asp:Label ID="instock" runat="server"></asp:Label><br />
                            </div>

                            
                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Issue Books" OnClick="b1_Click" />
                            </div>

                         
                        </form>
                    </div>
                </div>

            </div>
        </div>
        <!-- .card -->

    </div>
    <!--/.col-->
</asp:Content>
