<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="MyWeb.frmCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Clientes</title>

    <style> 
        body{
          
        }       
        .campo{
            padding : 10px;
        }
        .campo input[type="text"]{
            width:400px;
            float:right;          
        }
        .menu{
            font-weight:bold;
            text-transform:uppercase;
            margin-left:150px;
        }
        .campo input[type="button"]{

           float:right                               
        }
        .lb{
            color:green;
        }
        .lbRX{
            color:red;
        }
        .container{
            width:500px;
        }
       
        .container2{
            margin-left: 600px;
        }
    </style>

</head>
<body>
    <section class="container2">
    <h1 class="menu" >Cadastre Seu Contato</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label CssClass="lb" ID="lbMenssagem" runat="server" Text=" "></asp:Label>
            <asp:Label CssClass="lbRX" ID="lbMenssagemRX" runat="server" Text=" "></asp:Label>            
        </div>

        <div class="container">

        <div class="campo">
            <asp:TextBox runat="server" ID="txtId" Visible="false"></asp:TextBox>
        </div>
        <div class="campo">
            <asp:Label runat="server" AssociatedControlID="txtNome"> Nome: </asp:Label>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="90"></asp:TextBox>
        </div>
        <div class="campo">
            <asp:Label runat="server" AssociatedControlID="txtEmail" >Email: </asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="90"></asp:TextBox>
        </div>
        <div class="campo">
            <asp:Label runat="server" AssociatedControlID="txtNumero" >Contato: </asp:Label>
            <asp:TextBox ID="txtNumero" runat="server" MaxLength="13"></asp:TextBox>
        </div>
        <div class="campo">
            <asp:Button runat="server" ID="btnInserir" OnClick="btnInserir_Click" Width="97" Text="Inserir"/>
            <asp:Button runat="server" ID="btnLimpar" OnClick="btnLimpar_Click" Width="97" Text="Limpar"/>
            <asp:Button runat="server" ID="btnAlterar" OnClick="btnAlterar_Click" Width="97" Text="Alterar"/>
            <asp:Button runat="server" ID="btnDeletar" OnClick="btnDeletar_Click" Width="97" Text="Deletar"/>

        </div>

        </div>

        <br />
        <h2 class="menu">Lista de Contatos</h2>

        <div>           
            <asp:GridView ID="gvw_cliente"  runat="server"  AutoGenerateColumns="False" OnRowCommand="gvw_cliente_RowCommand" Width="727px" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                                        
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="true"/>
                    <asp:BoundField DataField="CLI_NOME" HeaderText="NOME" />
                    <asp:BoundField DataField="CLI_EMAIL" HeaderText="EMAIL" />
                    <asp:BoundField DataField="CLI_NUMERO" HeaderText="CONTATO" />

                    <asp:ButtonField CommandName="selecionar" HeaderText="Editar" ButtonType="Image" ImageUrl="~/img/editar.jpg"/>
                    <asp:ButtonField CommandName="deletar" HeaderText="Deletar" ButtonType="Image" ImageUrl="~/img/deleta.jpg" />

                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>

    </form>
  </section>
</body>
</html>
