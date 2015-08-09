Ext.define('Datie.model.listModel', {    
	extend: 'Ext.data.Model',
    config: {
        fields: [
        {name: '$id ', type: 'int'},
        {name: 'ShopId', type: 'int'},
        {name: 'ShopName', type: 'string'},
        {name: 'ShopAddress', type: 'string'},
        {name: 'District', type: 'string'},
        {name: 'Food', type: 'string'},
        {name: 'ShopPhone', type: 'string'},
        {name: 'ShopDescription', type: 'string'},
        {name: 'ShopPriceMid', type: 'string'},
        {name: 'ShopTimeMid', type: 'string'},
        {name: 'ShopIsDeleted', type: 'boolean'},        
        {name: 'ShopRate', type: 'int'},
        {name: 'Image', type: 'string'},
        {name: 'ThumbnailLink', type: 'string'}


         ],
        //      proxy: {
        //     method: 'GET',
        //     type: 'ajax',
        //     url: 'http://datie3.somee.com/api/Datie/',
        //     reader:{
        //     type: 'json',
        //     method: 'GET',
        //     //rootProperty: 'Shop'
        // }
        //  }
    },
});