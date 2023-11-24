Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
    Private Sub AboutMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMeToolStripMenuItem.Click
        frmAbout.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            System.Diagnostics.Process.Start("http://www.segtics.com")
        Catch
            'Code to handle the error.
        End Try
    End Sub

    Private Sub btnSelectFile_Click(sender As Object, e As EventArgs) Handles btnSelectFile.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            MessageBox.Show("File uploaded successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = OpenFileDialog1.FileName

            Dim sha512 As SHA512 = SHA512Managed.Create()
            Dim data As Byte() = File.ReadAllBytes(TextBox1.Text)
            Dim hash As Byte() = sha512.ComputeHash(data)
            Dim stringBuilder As New StringBuilder()

            For i As Integer = 0 To hash.Length - 1
                stringBuilder.Append(hash(i).ToString("X2"))
            Next

            TextBox2.Text = stringBuilder.ToString().ToLower

        End If
    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            MessageBox.Show("File uploaded successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox1.Text = OpenFileDialog1.FileName


            Dim sha512 As SHA512 = SHA512Managed.Create()
            Dim data As Byte() = File.ReadAllBytes(TextBox1.Text)
            Dim hash As Byte() = sha512.ComputeHash(data)
            Dim stringBuilder As New StringBuilder()

            For i As Integer = 0 To hash.Length - 1
                stringBuilder.Append(hash(i).ToString("X2"))
            Next

            TextBox2.Text = stringBuilder.ToString().ToLower

        End If
    End Sub

    Private Sub btnCreateHash_Click(sender As Object, e As EventArgs) Handles btnCreateHash.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("First select file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "txt|*.txt"
            Dim resultadoSFD As String
            saveFileDialog1.ShowDialog()
            resultadoSFD = saveFileDialog1.FileName

            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)

            Dim lastModified As String
            lastModified = infoReader.LastWriteTime

            Try
                Dim sw As New IO.StreamWriter(resultadoSFD)
                sw.Write("****************************************" & vbCrLf)
                sw.Write("******* SEGTICS SOLUCIONES S.A.S *******" & vbCrLf)
                sw.Write("****************************************" & vbCrLf)
                sw.Write("********* CHRONOLOGICAL STAMP **********" & vbCrLf)
                sw.Write("****************************************" & vbCrLf)
                sw.Write("Current Date      : " & DateTime.Now.ToString("dd/MM/yyyy") & vbCrLf)
                sw.Write("Current Time      : " & DateTime.Now.ToShortTimeString() & vbCrLf)
                sw.Write("" & vbCrLf)
                sw.Write("********** File Information ***********" & vbCrLf)
                sw.Write("File Path         : " & OpenFileDialog1.FileName & vbCrLf)
                sw.Write("Computer Name     : " & System.Windows.Forms.SystemInformation.ComputerName & vbCrLf)
                sw.Write("Last Modified     : " & lastModified & vbCrLf)
                sw.Write("" & vbCrLf)
                sw.Write("Hash SHA512       : " & TextBox2.Text & vbCrLf)
                sw.Flush()
                sw.Close()

                TextBox1.Text = ""
                TextBox2.Text = ""
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub SaveResultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveResultToolStripMenuItem.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("First select file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "txt|*.txt"
            Dim resultadoSFD As String
            saveFileDialog1.ShowDialog()
            resultadoSFD = saveFileDialog1.FileName

            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)

            Dim lastModified As String
            lastModified = infoReader.LastWriteTime

            Try
                Dim sw As New IO.StreamWriter(resultadoSFD)
                sw.Write("****************************************" & vbCrLf)
                sw.Write("******* SEGTICS SOLUCIONES S.A.S *******" & vbCrLf)
                sw.Write("****************************************" & vbCrLf)
                sw.Write("********* CHRONOLOGICAL STAMP **********" & vbCrLf)
                sw.Write("****************************************" & vbCrLf)
                sw.Write("Current Date      : " & DateTime.Now.ToString("dd/MM/yyyy") & vbCrLf)
                sw.Write("Current Time      : " & DateTime.Now.ToShortTimeString() & vbCrLf)
                sw.Write("" & vbCrLf)
                sw.Write("********** File Information ***********" & vbCrLf)
                sw.Write("File Path         : " & OpenFileDialog1.FileName & vbCrLf)
                sw.Write("Computer Name     : " & System.Windows.Forms.SystemInformation.ComputerName & vbCrLf)
                sw.Write("Last Modified     : " & lastModified & vbCrLf)
                sw.Write("" & vbCrLf)
                sw.Write("Hash SHA512       : " & TextBox2.Text & vbCrLf)
                sw.Flush()
                sw.Close()

                TextBox1.Text = ""
                TextBox2.Text = ""
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
