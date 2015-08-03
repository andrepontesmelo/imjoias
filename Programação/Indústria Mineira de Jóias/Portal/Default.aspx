<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Portal._Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Protótipo de digitação de mercadoria</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    </div>
        Cliente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCliente" autocomplete="off" runat="server" Width="573px"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtenderCliente" runat="server" 
            FirstRowSelected="True" MinimumPrefixLength="1" 
            ServiceMethod="ObterListaAutoCompletarPessoas" ServicePath="~/WebService1.asmx" 
            TargetControlID="txtCliente" CompletionSetCount="20">
        </cc1:AutoCompleteExtender>
        <br />
        <br />
        <br />
        <br />
    
        Referência:
        <asp:TextBox ID="txtBox" AUTOCOMPLETE="OFF" runat="server" ontextchanged="txtBox_TextChanged" 
            AutoPostBack="True"></asp:TextBox>
        
        <asp:Image ID="Image1" runat="server" />
        
        <br />
            
            
        Peso:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:TextBox ID="txtPeso" runat="server" ontextchanged="txtPeso_TextChanged"></asp:TextBox>
    
        <br />
        
    
        <asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
            Text="Adicionar" />
    
    <asp:Label ID="lblReferenciaNaoEncontrada" runat="server" ForeColor="#FF3300" 
        Text="Referência inválida!" Font-Size="Larger" Visible="False"></asp:Label>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
        CombineScripts="True">
    </cc1:ToolkitScriptManager>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        ServiceMethod="GetCompletionList" TargetControlID="txtBox" 
        ServicePath="~/WebService1.asmx" FirstRowSelected="True" 
        MinimumPrefixLength="1">
    </cc1:AutoCompleteExtender>
               
    
        <br />
               
    
    <asp:BulletedList ID="BulletedList1" runat="server">
    </asp:BulletedList>
               
    <asp:Label ID="lblTotal" runat="server" Enabled="False" EnableTheming="True" 
        Font-Bold="True"></asp:Label>
            </ContentTemplate>
    </asp:UpdatePanel>  
   
    </form>
</body>
</html>
