<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.about_wb = New System.Windows.Forms.WebBrowser()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'about_wb
        '
        Me.about_wb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.about_wb.Location = New System.Drawing.Point(0, 0)
        Me.about_wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.about_wb.Name = "about_wb"
        Me.about_wb.Size = New System.Drawing.Size(846, 496)
        Me.about_wb.TabIndex = 0
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 496)
        Me.Controls.Add(Me.about_wb)
        Me.Name = "About"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "About"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents about_wb As WebBrowser
End Class

