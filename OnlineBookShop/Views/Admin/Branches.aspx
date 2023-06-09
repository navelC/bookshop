﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Branches.aspx.cs" Inherits="OnlineBookShop.Views.Admin.Branches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Branches</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Branch Name</label>
                    <input type="text" placeholder="Name" autocomplete="off" class="form-control" runat="server" id="txtBrName" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">Branch Location</label>
                    <input type="text" placeholder="Location" autocomplete="off" class="form-control" runat="server" id="txtLocation" />
                </div>

                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                    <div class="col d-grid">
                        <asp:Button Text="Update" runat="server" class="btn-warning btn-block btn" ID="btnUpdate" OnClick="btnUpdate_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Save" runat="server" class="btn-success btn-block btn" ID="btnSave" OnClick="btnSave_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Delete" runat="server" class="btn-danger btn-block btn" ID="btnDelete" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="grvBranchesList" runat="server" class="table " CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grvBranches_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Teal" Font-Bold="false" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
