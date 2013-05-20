Public Class Form1
    Dim ID, CanBeCancel, type, Accept_NpcID As Integer, questname As String
    Dim unlock_questid, sort, isdead, isoffline, sequence, completedo_selectitemmodel As Integer
    Dim wayfinding, Sex, Job, acceptdo_jump, acceptdo_jumpx As Integer
    Dim acceptdo_jumpy, limit_playerlv_low, limit_playerlv_high, sect As Integer
    Dim Isitemempty, Ispanterempty, acceptdo_item1, acceptdo_item2, acceptdo_item3 As Integer
    Dim acceptdo_itemnum1, acceptdo_itemnum2, acceptdo_itemnum3 As Integer
    Dim complete_NPCID, complete_reqIa, complete_reqIb, complete_reqIc, complete_reqIIa, complete_reqIIb, complete_reqIIc As Integer
    Dim complete_reqIIIa, complete_reqIIIb, complete_reqIIIc, complete_itemempty, complete_deleteitem As Integer
    Dim complete_addexp, complete_addteamexp, complete_familexp, complete_addmoney, complete_addcoin, complete_frame, complete_addseniority As Integer
    Dim completedo_additemIa, completedo_additemIb, completedo_additemIIa, completedo_additemIIb, completedo_additemIIIa As Integer
    Dim completedo_additemIIIb, completedo_additemIVa, completedo_additemIVb, completedo_additemVa, completedo_additemVb As Integer

    '任务TYPE联动
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Select Case ComboBox2.Text
            Case "找人"
                complete_reqIa_1.Text = "NPCID"
                complete_reqIb_1.Text = "无意义"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 1
            Case "送东西"
                complete_reqIa_1.Text = "指定道具ID"
                complete_reqIb_1.Text = "指定道具数量"
                complete_reqIc_1.Text = "送到NPCID"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 2
            Case "招募"
                complete_reqIa_1.Text = "伙伴role ID"
                complete_reqIb_1.Text = "无意义"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 3
            Case "杀怪1"
                complete_reqIa_1.Text = "指定monster ID"
                complete_reqIb_1.Text = "数量"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 4
            Case "杀怪2"
                complete_reqIa_1.Text = "指定monster ID"
                complete_reqIb_1.Text = "指定monster 等级"
                complete_reqIc_1.Text = "指定monster 数量"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 5
            Case "护送"
                complete_reqIa_1.Text = "护送NPCid"
                complete_reqIb_1.Text = "完成任务的MAP ID"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 6
            Case "区域完成"
                complete_reqIa_1.Text = "玩家需要达到的MAP ID"
                complete_reqIb_1.Text = "无意义"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 7
            Case "杀怪取物"
                complete_reqIa_1.Text = "指定怪物的monsterID"
                complete_reqIb_1.Text = "掉落个数"
                complete_reqIc_1.Text = "指定掉落item"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 8
            Case "到达等级"
                complete_reqIa_1.Text = "需要玩家升级至的等级"
                complete_reqIb_1.Text = "无意义"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 9
            Case "引导任务"
                complete_reqIa_1.Text = "无意义"
                complete_reqIb_1.Text = "无意义"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 100
            Case ""
                complete_reqIa_1.Text = "无意义"
                complete_reqIb_1.Text = "无意义"
                complete_reqIc_1.Text = "无意义"
                complete_reqIIa_1.Text = "无意义"
                complete_reqIIb_1.Text = "无意义"
                complete_reqIIc_1.Text = "无意义"
                complete_reqIIIa_1.Text = "无意义"
                complete_reqIIIb_1.Text = "无意义"
                complete_reqIIIc_1.Text = "无意义"
                type = 0
        End Select
        RichTextBox1.Enabled = True
        RichTextBox2.Enabled = True
        RichTextBox3.Enabled = True

    End Sub
    '主支任务
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "主线"
                sort = 1
            Case "支线"
                sort = 2
            Case "每日任务"
                sort = 3
        End Select
        'MsgBox(sort)
    End Sub
    '失败-死亡
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Select Case ComboBox3.Text
            Case "是"
                isdead = 1
            Case "否"
                isdead = 0
        End Select
    End Sub
    '失败-下线
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Select Case ComboBox4.Text
            Case "是"
                isoffline = 1
            Case "否"
                isoffline = 0
        End Select
    End Sub

    '任务名称
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        questname = TextBox1.Text
    End Sub
    '任务ID
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ID = TextBox2.Text
    End Sub
    '解锁ID
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        unlock_questid = TextBox3.Text
    End Sub
    '关卡ID
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        sequence = TextBox4.Text
    End Sub
    '接受任务后寻路NPC
    Private Sub TextBox61_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox61.TextChanged
        wayfinding = TextBox61.Text
    End Sub
    '接受任务NPC
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Accept_NpcID = TextBox5.Text
    End Sub
    '最低等级
    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        limit_playerlv_low = TextBox6.Text
    End Sub
    '最高等级
    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        limit_playerlv_high = TextBox7.Text
    End Sub
    '接受任务需要的包裹位
    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        Isitemempty = TextBox8.Text
    End Sub
    '接受任务需要的伙伴位
    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Ispanterempty = TextBox9.Text
    End Sub
    '接受任务给予道具1 item
    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        acceptdo_item1 = TextBox10.Text
    End Sub
    '接受任务给予道具1 数量
    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        acceptdo_itemnum1 = TextBox11.Text
    End Sub
    '接受任务给予道具2 item
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        acceptdo_item2 = TextBox12.Text
    End Sub
    '接受任务给予道具2 数量
    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        acceptdo_itemnum2 = TextBox13.Text
    End Sub
    '接受任务给予道具3 item
    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged
        acceptdo_item3 = TextBox14.Text
    End Sub
    '接受任务给予道具3 数量
    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        acceptdo_itemnum3 = TextBox15.Text
    End Sub
    '性别
    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        Select Case ComboBox8.Text
            Case "男"
                Sex = 1
            Case "女"
                Sex = 0
            Case "皆可"
                Sex = 2
        End Select
    End Sub
    '职业
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        Select Case ComboBox9.Text
            Case "剑侠"
                Job = 1
            Case "刀客"
                Job = 2
            Case "翎羽"
                Job = 3
            Case "力士"
                Job = 4
            Case "乐师"
                Job = 5
            Case "无限制"
                Job = 0
        End Select
    End Sub
    '接受跳转地图
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        acceptdo_jump = ComboBox5.Text
    End Sub
    '接受跳转地图 X
    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged
        acceptdo_jumpx = TextBox17.Text
    End Sub
    '接受跳转地图 Y
    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        acceptdo_jumpy = TextBox18.Text
    End Sub
    '门派
    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        Select Case ComboBox10.Text
            Case "少林"
                sect = 1
            Case "武当"
                sect = 2
            Case "峨眉"
                sect = 3
            Case "无限制"
                sect = 4
        End Select
    End Sub
    '完成任务NPC
    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged
        complete_NPCID = TextBox18.Text
    End Sub
    '第一组完成条件1
    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged
        complete_reqIa = TextBox19.Text
    End Sub
    '第一组完成条件2
    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged
        complete_reqIb = TextBox20.Text
    End Sub
    '第一组完成条件3
    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.TextChanged
        complete_reqIc = TextBox21.Text
    End Sub
    '第二组完成条件1
    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox22.TextChanged
        complete_reqIIa = TextBox22.Text
    End Sub
    '第二组完成条件2
    Private Sub TextBox23_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox23.TextChanged
        complete_reqIIb = TextBox23.Text
    End Sub
    '第二组完成条件3
    Private Sub TextBox24_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox24.TextChanged
        complete_reqIIc = TextBox24.Text
    End Sub
    '第三组完成条件1
    Private Sub TextBox25_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox25.TextChanged
        complete_reqIIIa = TextBox25.Text
    End Sub
    '第三组完成条件2
    Private Sub TextBox26_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox26.TextChanged
        complete_reqIIIb = TextBox26.Text
    End Sub
    '第三组完成条件3
    Private Sub TextBox27_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox27.TextChanged
        complete_reqIIIc = TextBox27.Text
    End Sub
    '完成任务需要包裹位
    Private Sub TextBox28_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox28.TextChanged
        complete_itemempty = TextBox28.Text
    End Sub
    '完成任务后删除道具
    Private Sub TextBox59_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox59.TextChanged
        complete_deleteitem = TextBox59.Text
    End Sub
    '经验
    Private Sub TextBox29_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox29.TextChanged
        complete_addexp = TextBox29.Text
    End Sub
    '伙伴经验
    Private Sub TextBox30_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox30.TextChanged
        complete_addteamexp = TextBox30.Text
    End Sub
    '帮贡
    Private Sub TextBox31_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox31.TextChanged
        complete_familexp = TextBox31.Text
    End Sub
    '银两
    Private Sub TextBox32_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox32.TextChanged
        complete_addmoney = TextBox32.Text
    End Sub
    '元宝
    Private Sub TextBox33_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox33.TextChanged
        complete_addcoin = TextBox33.Text
    End Sub
    '声望
    Private Sub TextBox34_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox34.TextChanged
        complete_frame = TextBox34.Text
    End Sub
    '阅历
    Private Sub TextBox35_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox35.TextChanged
        complete_addseniority = TextBox35.Text
    End Sub
    '道具给予模式
    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        Select Case ComboBox7.Text
            Case "自动"
                completedo_selectitemmodel = 1
            Case "手动"
                completedo_selectitemmodel = 0
        End Select
    End Sub
    '给予的道具1
    Private Sub TextBox36_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox36.TextChanged
        completedo_additemIa = TextBox36.Text
    End Sub
    '给予的道具2
    Private Sub TextBox40_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox40.TextChanged
        completedo_additemIIa = TextBox40.Text
    End Sub
    '给予的道具3
    Private Sub TextBox39_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox39.TextChanged
        completedo_additemIIIa = TextBox39.Text
    End Sub
    '给予的道具4
    Private Sub TextBox38_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox38.TextChanged
        completedo_additemIVa = TextBox38.Text
    End Sub
    '给予的道具5
    Private Sub TextBox37_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox37.TextChanged
        completedo_additemVa = TextBox37.Text
    End Sub
    '给予的道具1 数量
    Private Sub TextBox41_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox41.TextChanged
        completedo_additemIb = TextBox41.Text
    End Sub
    '给予的道具2 数量
    Private Sub TextBox44_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox44.TextChanged
        completedo_additemIIb = TextBox44.Text
    End Sub
    '给予的道具3 数量
    Private Sub TextBox43_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox43.TextChanged
        completedo_additemIIIb = TextBox43.Text
    End Sub
    '给予的道具4 数量
    Private Sub TextBox42_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox42.TextChanged
        completedo_additemIVb = TextBox42.Text
    End Sub
    '给予的道具5 数量
    Private Sub TextBox45_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox45.TextChanged
        completedo_additemVb = TextBox45.Text
    End Sub
    Dim questdesc, questdirc, questend, acceptquestname As String
    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        questdesc = RichTextBox1.Text
    End Sub
    '导出
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        questend = "<span class = 'normal'>" + string_1() + "<"
    End Sub
    Function string_1()
        Return ""
    End Function
End Class
