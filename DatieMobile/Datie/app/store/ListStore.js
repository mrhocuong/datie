Ext.define("Datie.store.ListStore",{
extend: 'Ext.data.Store',
requires: [
'Datie.model.listModel',
],
config:{
	autoLoad: true,
	model: 'Datie.model.listModel',
	proxy: {
            type: 'ajax',
            method: 'GET',
            url: 'http://datie3.somee.com/api/Datie',
            reader:{
            type: 'json',
        }
         },
	  listeners: {
            load: function(st, g, s, o, opts) {
                st.each(function(record) {
                    console.log(record.get('ShopId') + ' - ' + record.get('ShopName')+ ' - ' + record.get('ShopAddress')
                    	+ ' - ' + record.get('ShopDescription')+ ' - ' + record.get('ShopRate'));
                });
            }
    }
},
});