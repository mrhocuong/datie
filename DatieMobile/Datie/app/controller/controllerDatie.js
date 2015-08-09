Ext.define("Datie.controller.controllerDatie",{
extend: 'Ext.app.Controller',

config: {
	refs: {
		userBtn: "#userBtn",
		logInBtn: "#logInBtn",
	},
	control:{
		userBtn: {
			tap: "switchLogin",
		},
		logInBtn: {
			tap: "login",
		}
	},
},

switchLogin: function()
{
	        Ext.Viewport.setActiveItem({ xtype: 'login-view' }); 
        console.log(Ext.Viewport.getActiveItem().xtype);
}, 

login: function()
{
	        Ext.Viewport.setActiveItem({ xtype: 'main' }); 
        console.log(Ext.Viewport.getActiveItem().xtype);
}
});