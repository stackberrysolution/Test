Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' manal
        'tbBarCode.Text = "%B1234690022029738^SHALASH/MOHAMMAD S        ^2304201000000000000000430000000?;4275690022029738=23042010000043000000?"
        ' manal cards
        txtCardID.Focus()
        ''txtCardID.Text = "%B1234690022029738^SHALASH/MOHAMMAD S        ^2304201000000000000000430000000?;4275690022029738=23042010000043000000?"
        ''Dim CardID As String = txtCardID.Text
        ''Dim len As Integer = CardID.Split("^").Length

        Dim xx1 As Cards = New Cards(txtCardID.Text, TxtSecretID.Text, TxtMode.Text)

        xx1.setCustomerInformation(txtFirstName.Text, txtLastName.Text, txtAddress1.Text, txtAdress2.Text, txtCity.Text, TxtState.Text, TxtZipCode.Text, TxtCountry.Text, TxtPhone.Text, TxtEmail.Text, TxtCompNm.Text)
        xx1.swipe(txtCardID.Text)
        xx1.setCCInformation(TxtPaymentAccount.Text, TxtCardExpier.Text, TxtVV2.Text)
        xx1.sale(TxtAmount.Text)
        xx1.process()
        xx1.addLevel2Information("0", "0", "1", "1", "0", "", "",,,,,,,,,,, "pos",, "MOHAMMAD",,,,,,,)

        Dim ia As Integer
        For ia = 0 To 99
            xx1.addLineItem("0.1", ia,, "oil", "", "026102418970" + ia,,,,,,,,,,,,,,,,,,,)
        Next ia
        xx1.setRebillingInformation(TxtAmount.Text, "09/08/2019", "09/08/2019", "")
        xx1.sale(TxtAmount.Text)
        xx1.GetRandomString(10)
        xx1.update(txtCardID.Text, TxtAmount.Text)
        xx1.setInvoiceID("1")
        xx1.setOrderID("1")
        xx1.setAmountTip("oil")
        xx1.setAmountTax("0")
        xx1.setAmountFood("1")
        xx1.setAmountMisc("1")
        xx1.setMemo("MOHAMMAD")
        xx1.setPhone(TxtPhone.Text)
        xx1.setEmail(TxtEmail.Text)
        xx1.setCompanyName(TxtCompNm.Text)
        xx1.getSingleTransactionQuery("09/08/2019", "10/08/2019", "1",)
        xx1.generateTPS("Bill 1", "HMAC_SHA256")
        xx1.calcTPS()
        xx1.generateURL(TxtMerchentName.Text, TxtReturnURL.Text, "SALE", "Yes", "Yes", TxtAmount.Text, "Yes", "Yes",,,,,,,,,, "remote_url",,,)
        xx1.setHashType("MOHAMMAD")
        xx1.encodeURL("MOHAMMAD")
        xx1.calcURLResponse()
        xx1.setReceiptURL()
        xx1.process()
        xx1.getTransactionReport("04-09-2019", "05-09-2019",,,)
        xx1.response = "MESSAGE=([^&$]+)"
        xx1.getMessage()

        '********************************
        'اقارن مع كود البطاقة كامل
        '********


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click

        If RadioButton1.Checked Then
            txtCardID.Focus()
        End If
    End Sub


    Private Sub txtCardID_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ''Dim strarr2() As String
            ''strarr2 = txtCardID.Text.Split("^")
            ''If strarr2.Length < 2 Then
            ''    txtCardID.Clear()
            ''    txtCardID.Focus()
            ''    Exit Sub
            ''End If

            ''Dim CardNum As String
            ''CardNum = strarr2(0).Trim().Substring(strarr2(0).Length - 16, 16)
        End If
    End Sub

    Private Sub txtCardID_TextChanged(sender As Object, e As EventArgs) Handles txtCardID.TextChanged
        Dim strarr2() As String
        strarr2 = txtCardID.Text.Split("^")
        If strarr2.Length < 2 Then
            txtCardID.Clear()
            txtCardID.Focus()
            Exit Sub
        End If

        Dim CardNum As String
        TxtPaymentAccount.Text = strarr2(0).Trim().Substring(strarr2(0).Length - 16, 16)

        If strarr2(2).Trim().Contains("=") Then
            Dim numberString As Integer
            numberString = strarr2(2).Trim.IndexOf("=")
            TxtCardExpier.Text = strarr2(2).Trim().Substring(numberString + 1, 2)

        End If
        If strarr2(1).Trim().Contains("/") Then
            Dim numberString() As String

            numberString = strarr2(1).Split("/")
            txtFirstName.Text = numberString(1)
            txtLastName.Text = numberString(0)
        End If
        TxtSecretID.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ''        There are three outcomes when processing credit card transactions

        ''Approved
        ''        Declined
        ''        Error
        'Dim accountID As String = "Merchant's Account ID Here"
        'Dim secretKey As String = "Merchant's Secret Key Here"
        'Dim mode As String = "TEST"


        Dim xx1 As Cards = New Cards(txtCardID.Text, TxtSecretID.Text, TxtMode.Text)

        xx1.setCustomerInformation(txtFirstName.Text, txtLastName.Text, txtAddress1.Text, txtAdress2.Text, txtCity.Text, TxtState.Text, TxtZipCode.Text, TxtCountry.Text, TxtPhone.Text, TxtEmail.Text, TxtCompNm.Text)
        ' xx1.swipe(txtCardID.Text)
        xx1.setCCInformation(TxtPaymentAccount.Text, TxtCardExpier.Text, TxtVV2.Text)
        xx1.sale(TxtAmount.Text)
        xx1.process()



        If xx1.isSuccessfulTransaction() Then
            Console.Write("Transaction Status: " + xx1.getStatus() + Environment.NewLine)
            Console.Write("Transaction Message: " + xx1.getMessage() + Environment.NewLine)
            Console.Write("Transaction ID: " + xx1.getTransID() + Environment.NewLine)
            Console.Write("AVS Result: " + xx1.getAVS() + Environment.NewLine)
            Console.Write("CVV2 Result: " + xx1.getCVV2() + Environment.NewLine)
            Console.Write("Masked Payment Account: " + xx1.getMaskedPaymentAccount() + Environment.NewLine)
            Console.Write("Card Type: " + xx1.getCardType() + Environment.NewLine)
            Console.Write("Authorization Code: " + xx1.getAuthCode() + Environment.NewLine)
        Else
            Console.Write("Transaction Error: " + xx1.getMessage() + Environment.NewLine)
        End If
    End Sub


    Private Sub TxtSecretID_TextChanged(sender As Object, e As EventArgs) Handles TxtSecretID.TextChanged

    End Sub

    Private Sub btnAch_Click(sender As Object, e As EventArgs) Handles btnAch.Click
        ''Dim accountID As String = "Merchant's Account ID Here"
        ''Dim secretKey As String = "Merchant's Secret Key Here"
        ''Dim mode As String = "TEST"

        Dim accountID As String = TxtAccountACHID.Text
        Dim secretKey As String = TxtSecretACHID.Text
        Dim mode As String = "TEST"

        Dim payment As Cards = New Cards(
            accountID,
            secretKey,
            mode
        )
        'txtFirstName.Text, txtLastName.Text, txtAddress1.Text, txtAdress2.Text, txtCity.Text, TxtState.Text, TxtZipCode.Text, TxtCountry.Text, TxtPhone.Text, TxtEmail.Text, TxtCompNm.Text)
        payment.setCustomerInformation(
            firstName:=txtFirstName.Text,
            lastName:=txtLastName.Text,
            address1:=txtAddress1.Text,
            address2:=txtAdress2.Text,
            city:=txtCity.Text,
            state:=TxtState.Text,
            zipCode:=TxtZipCode.Text,
            country:=TxtCountry.Text,
            phone:=TxtPhone.Text,
            email:=TxtEmail.Text
        )

        ' Routing Number: 123123123
        ' Account Number: 0523421
        ' Account Type: Checking
        ' ACH Document Type: WEB
        payment.setACHInformation(
            routingNum:=TxtRoutingNo.Text,
            accNum:=TxtAccountACHID.Text,
            accType:=TxtAccType.Text,
            docType:=TxtDocType.Text
        )

        payment.sale(TxtAmount.Text)

        payment.process()

        If payment.isSuccessfulTransaction() Then
            Console.Write("Transaction ID: " + payment.getTransID() + Environment.NewLine)
            Console.Write("Transaction Status: " + payment.getStatus() + Environment.NewLine)
            Console.Write("Transaction Message: " + payment.getMessage() + Environment.NewLine)
            Console.Write("Masked Payment Account: " + payment.getMaskedPaymentAccount() + Environment.NewLine)
            Console.Write("Bank Name: " + payment.GetBank() + Environment.NewLine)
        Else
            Console.Write("Transaction Error: " + payment.getMessage() + Environment.NewLine)
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        If RadioButton2.Checked = True Then
            txtCardIDACH.Focus()
        End If
    End Sub

    Private Sub txtCardIDACH_TextChanged(sender As Object, e As EventArgs) Handles txtCardIDACH.TextChanged
        Dim strarr2() As String
        strarr2 = txtCardIDACH.Text.Split("^")
        If strarr2.Length < 2 Then
            txtCardIDACH.Clear()
            txtCardIDACH.Focus()
            Exit Sub
        End If

        'Dim CardNum As String
        TxtAccountACHID.Text = strarr2(0).Trim().Substring(strarr2(0).Length - 16, 16)

        'If strarr2(2).Trim().Contains("=") Then
        '    Dim numberString As Integer
        '    numberString = strarr2(2).Trim.IndexOf("=")
        '    TxtCardExpier.Text = strarr2(2).Trim().Substring(numberString + 1, 2)

        'End If
        If strarr2(1).Trim().Contains("/") Then
            Dim numberString() As String

            numberString = strarr2(1).Split("/")
            txtFirstName.Text = numberString(1)
            txtLastName.Text = numberString(0)
        End If
        TxtSecretACHID.Focus()

    End Sub
    Sub Newss()
            MessageBox.Show("hello ahmad")
    End Sub
End Class




''Private Sub txtCardID_TextChanged(sender As Object, e As EventArgs)
''    Dim strarr2() As String
''    strarr2 = txtCardID.Text.Split("^")
''    If strarr2.Length < 2 Then
''        txtCardID.Clear()
''        txtCardID.Focus()
''        Exit Sub
''    End If

''    Dim CardNum As String
''    TxtPaymentAccount.Text = strarr2(0).Trim().Substring(strarr2(0).Length - 16, 16)

''    If strarr2(2).Trim().Contains("=") Then
''        Dim numberString As Integer
''        numberString = strarr2(2).Trim.IndexOf("=")
''        TxtCardExpier.Text = strarr2(2).Trim().Substring(numberString + 1, 2)

''    End If
''    If strarr2(1).Trim().Contains("/") Then
''        Dim numberString() As String

''        numberString = strarr2(1).Split("/")
''        txtFirstName.Text = numberString(1)
''        txtLastName.Text = numberString(0)
''    End If
''End Sub



''Private Sub txtCardID_TextChanged_1(sender As Object, e As EventArgs) Handles txtCardID.TextChanged
''    Dim strarr2() As String
''    strarr2 = txtCardID.Text.Split("^")
''    If strarr2.Length < 2 Then
''        txtCardID.Clear()
''        txtCardID.Focus()
''        Exit Sub
''    End If

''    Dim CardNum As String
''    TxtPaymentAccount.Text = strarr2(0).Trim().Substring(strarr2(0).Length - 16, 16)

''    If strarr2(2).Trim().Contains("=") Then
''        Dim numberString As Integer
''        numberString = strarr2(2).Trim.IndexOf("=")
''        TxtCardExpier.Text = strarr2(2).Trim().Substring(numberString + 1, 2)

''    End If
''    If strarr2(1).Trim().Contains("/") Then
''        Dim numberString() As String

''        numberString = strarr2(1).Split("/")
''        txtFirstName.Text = numberString(1)
''        txtLastName.Text = numberString(0)
''    End If
''End Sub
'''End If
'''End Sub




'End Class
