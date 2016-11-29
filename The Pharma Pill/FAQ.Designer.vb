<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAQ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAQ))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.wb_faq = New System.Windows.Forms.WebBrowser()
        Me.Panel1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.wb_faq)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(738, 471)
        Me.Panel1.TabIndex = 0
        '
        'wb_faq
        '
        Me.wb_faq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb_faq.Location = New System.Drawing.Point(0, 0)
        Me.wb_faq.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb_faq.Name = "wb_faq"
        Me.wb_faq.Size = New System.Drawing.Size(738, 471)
        Me.wb_faq.TabIndex = 0
        '
        'FAQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 471)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FAQ"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FAQ"
        Me.Panel1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents wb_faq As WebBrowser
End Class

