Ext.define("Datie.view.listView", {
	extend: 'Ext.List',
	xtype: 'li_list',
	config: {
		scrollable: true,
		itemTpl: Ext.XTemplate([
			'<div>',
			'<div><img src = {shopThumb} height="150px" width="340px"></div>',
			'<div>{shopName}</div>',
			'<div>{Description}</div>',
			'<div>Address: {shopAddress}</div>',			
			'<div>Rate: {rate}</div>',
			'</div>'
			].join('')),
		store: 'ListStore',
		width: '100%',
		height: '100%'
	}
});