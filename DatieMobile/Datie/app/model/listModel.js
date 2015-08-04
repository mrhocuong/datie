Ext.define('Datie.model.listModel', {    
	extend: 'Ext.data.Model',
    config: {
        fields: [
        {name: 'shopId', type: 'int'},
        {name: 'shopName', type: 'string'},
        {name: 'shopAddress', type: 'string'},
        {name: 'Description', type: 'string'},
        {name: 'rate', type: 'int'},
        {name: 'shopThumb', type: 'string'},


         ],
             proxy: {
            type: 'ajax',
            url: 'datalist.json',
            reader:{
            type: 'json',
            rootProperty: 'Shop'
        }
         }
    },
});