<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAsADO.aspx.cs" Inherits="MyDetailsViewSamples.WorkAsADO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>    
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="ReadOneValueButton" Text="Чтение логина записи" runat="server" OnClick="ReadOneValueButton_Click" />
            <%//добавить текст бокс куда я буду вписывать id и выдавать конкретную запись. РЕАЛИЗОВАТЬ. %>
        Результат:
            <asp:Label ID="ReadOneValueOutput" EnableViewState="false" runat="server" />
            <br />
            Id
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
        <hr />
        <!--Построчное считыванеи информации-->
        <asp:Button ID="ReadAllButton" Text="Чтение всех записи" runat="server" OnClick="ReadAllButton_Click" />
        Результат:
        <br />
        <asp:Label ID="ReadAllOutput" EnableViewState="false" runat="server" />
        <hr />
        <!--Построчное считывание информации-->
        Login
        <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
        <br />
        Passowrd
        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
        <br />
        Email
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox><br />
        <asp:Button ID="AddNewEntryButton" Text="Добавить новую запись" runat="server" OnClick="AddNewEntryButton_Click" />
        <asp:Label ID="ErrorOutput" runat="server" EnableViewState="false" />
        <hr />
        Id
        <asp:TextBox ID="IdToRemoveTextBox" runat="server" />
        <!--OnClientClick JavaScript функция, которая выполняется на стороне клиента до того как на сервер будет отправлен запрос.
        Если функция возвращает значение false - отправка запроса отменяется-->
        <asp:Button ID="RemoveByIdButton" Text="Удалить запись по ID" runat="server" OnClientClick="return confirm('Вы уверены, что хотите удалить запись?')"
            OnClick="RemoveByIdButton_Click" />
        <asp:Label ID="ErrorOutput2" runat="server" EnableViewState="false" />
        </div>
    </form>
</body>
</html>
