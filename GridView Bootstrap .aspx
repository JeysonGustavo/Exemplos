<asp:GridView ID="grdDadosHistorico" HeaderStyle-BackColor="#135510" HeaderStyle-ForeColor="White"
	runat="server"
	AllowPaging="true"
	AutoGenerateColumns="False"
	PageSize="60"
	HorizontalAlign="Center"
	CellPadding="4"
	ForeColor="#333333"
	GridLines="None"
	ShowFooter="True"
	AllowSorting="False"
	EditRowStyle-HorizontalAlign="Center"
	EditRowStyle-VerticalAlign="Middle"
	EmptyDataRowStyle-HorizontalAlign="Center"
	EmptyDataRowStyle-VerticalAlign="Middle"
	FooterStyle-HorizontalAlign="Center"
	FooterStyle-VerticalAlign="Middle"
	HeaderStyle-HorizontalAlign="Center"
	HeaderStyle-VerticalAlign="Middle"
	RowStyle-VerticalAlign="Middle"
	RowStyle-HorizontalAlign="Center"
	SelectedRowStyle-HorizontalAlign="Center"
	SelectedRowStyle-VerticalAlign="Middle"
	SortedAscendingCellStyle-HorizontalAlign="Center"
	SortedAscendingCellStyle-VerticalAlign="Middle"
	Width="100%" OnPageIndexChanging="grdDadosHistorico_PageIndexChanging" OnSelectedIndexChanged="grdDadosHistorico_SelectedIndexChanged">
	<AlternatingRowStyle BackColor="#e1e4e1" />

	<Columns>
		<asp:BoundField DataField="SERIAL POS" HeaderText="SERIAL POS" SortExpression="SERIAL POS" ItemStyle-CssClass="griditemL" HeaderStyle-CssClass="gridheaderL" NullDisplayText=" - ">
			<HeaderStyle CssClass="gridheaderL"></HeaderStyle>
			<ItemStyle CssClass="griditemL"></ItemStyle>
		</asp:BoundField>

		<asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" ItemStyle-CssClass="griditem" HeaderStyle-CssClass="gridheader" NullDisplayText=" - ">
			<HeaderStyle CssClass="gridheader"></HeaderStyle>
			<ItemStyle CssClass="griditem"></ItemStyle>
		</asp:BoundField>

		<asp:BoundField DataField="ESTAB. ANTIGO(S)" HeaderText="ESTAB. ANTIGO(S)" SortExpression="ESTAB. ANTIGO(S)" ItemStyle-CssClass="griditem" HeaderStyle-CssClass="gridheader" NullDisplayText=" - ">
			<HeaderStyle CssClass="gridheader"></HeaderStyle>
			<ItemStyle CssClass="griditem"></ItemStyle>
		</asp:BoundField>

		<asp:BoundField DataField="ESTAB. ATUAL" HeaderText="ESTAB. ATUAL" SortExpression="ESTAB. ATUAL" ItemStyle-CssClass="griditem" HeaderStyle-CssClass="gridheader" NullDisplayText=" - ">
			<HeaderStyle CssClass="gridheader"></HeaderStyle>
			<ItemStyle CssClass="griditem"></ItemStyle>
		</asp:BoundField>

		<asp:BoundField DataField="DATA OPERAÇÃO" HeaderText="DATA OPERAÇÃO" SortExpression="DATA OPERAÇÃO" ItemStyle-CssClass="griditem" HeaderStyle-CssClass="gridheader" NullDisplayText=" - ">
			<HeaderStyle CssClass="gridheader"></HeaderStyle>
			<ItemStyle CssClass="griditem"></ItemStyle>
		</asp:BoundField>

		<asp:BoundField DataField="MODIFICADO POR:" HeaderText="MODIFICADO POR:" SortExpression="MODIFICADO POR:" ItemStyle-CssClass="griditem" HeaderStyle-CssClass="gridheader" NullDisplayText=" - ">
			<HeaderStyle CssClass="gridheader"></HeaderStyle>
			<ItemStyle CssClass="griditem"></ItemStyle>
		</asp:BoundField>
	</Columns>

	<PagerStyle CssClass="pagination-ys" />

</asp:GridView>