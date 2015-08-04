// var store = new Ext.data.Store({
// 	autoLoad: true,
// 	model: 'Datie.model.listModel',
// 	proxy:{
// 		type: 'ajax',
// 		url: 'datalist.json',
// 		reader:{
// 			type: 'json',
// 			rootProperty: 'Shop'
// 		},
// 	},
// 		listeners: {
//          load: function(){
//             console.log(store.getRange());
//          }
//       }
// });
Ext.define("Datie.store.ListStore",{
extend: 'Ext.data.Store',
requires: [
'Datie.model.listModel'
],
config:{
	autoLoad: true,
	model: 'Datie.model.listModel',
	// proxy:{
	// 	type: 'ajax',
	// 	url: 'datalist.json',
	// 	reader:{
	// 		type: 'json',
	// 		rootProperty: 'Shop'
	// 	}
	// },
	  listeners: {
            load: function(st, g, s, o, opts) {
                st.each(function(record) {
                    console.log(record.get('shopId') + ' - ' + record.get('shopName')+ ' - ' + record.get('shopAddress')
                    	+ ' - ' + record.get('Description')+ ' - ' + record.get('rate'));
                });
            }
    }
}
});