Ext.define("Datie.view.listView", {
	extend: 'Ext.List',
	xtype: 'li_list',
	config: {
		scrollable: true,
		itemTpl: Ext.XTemplate([
			'<div>',
			'<div><b>{ShopName}</b></div>',
			'<div><img src = {ThumbnailLink} height="150" width="340"></div>',
			'<div>{ShopDescription}</div>',
			'<div><b>Address: </b>{ShopAddress}</div>',			
			'<div><b>Rate: </b>{ShopRate}</div>',
			'</div>'
			].join('')),
		store: 'ListStore',
		width: '100%',
		height: '100%'
	}
});