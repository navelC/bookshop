<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Selling.aspx.cs" Inherits="OnlineBookShop.Views.Seller.Selling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            var PGrid = document.getElementById('<%=grvBillsList.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100, top=100, width=1024, height=768, toolbar=0, scrollbar=1, status=0, resizable=1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            //PWin.close();
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            
        </div>

        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <h3 class="text-success text-center">Book Details</h3>
                    </div>
                </div>

                <div class="row">

                    <div class="row mt-3 mb-3">
                        <div class="col d-grid">
                            <asp:DropDownList ID="ddlBranch" class="form-control" runat="server">  </asp:DropDownList>  
                            <asp:Label ID="Label2" runat="server" class="text-danger text-center"></asp:Label>  
                            <asp:Button ID="Button1" runat="server" Text="Branch Search" OnClick="Button1_Click1" Style="height: 26px" />
                        </div>
                    </div>

                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Book Name</label>
                            <input type="text" placeholder="Book's Name" autocomplete="off" class="form-control" runat="server" id="txtBName" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Book Price</label>
                            <input type="text" placeholder="Price" autocomplete="off" class="form-control" runat="server" id="txtBPrice" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Quantity</label>
                            <input type="text" placeholder="Quantity" autocomplete="off" class="form-control" runat="server" id="txtBQty"/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label for="" class="form-label text-success">Billing Date</label>
                            <input type="datetime" runat="server" id="hi" value="dd. MM. yyyy" />
                        </div>
                    </div>

                    <div class="row mt-3 mb-3">
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                        <div class="col d-grid">
                            <asp:Button Text="Add to Bill" runat="server" class="btn-success btn-block btn" ID="btnAddToBill" OnClick="btnAddToBill_Click"/>
                        </div>
                    </div>
                </div>

                <div class="row mt-5">
                    <h3 class="text-success text-center">Book List</h3>
                    <div class="col">
                        <asp:GridView ID="grvBooksList" runat="server" class="table " CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grvBooksList_SelectedIndexChanged">
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
            <div class="col-md-7">
                    <div class="col">
                        <h3 class="text-success text-center" style="color:crimson">Client's Bill</h3>
                    </div>

                    <div class="col">
                        <asp:GridView ID="grvBillsList" runat="server" class="table " CellPadding="4" ForeColor="#333333" GridLines="None" >
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#0099ff" Font-Bold="false" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>

                        <div class=" d-grid">
                            <asp:Label runat="server" ID="txtGridTotal" class="text-danger text-center"></asp:Label>
                            <asp:Button Text="Print" runat="server" class="btn-warning btn-block btn" ID="btnPrint" OnClientClick="PrintBill()" OnClick="btnPrint_Click"/>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>