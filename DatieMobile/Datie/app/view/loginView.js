Ext.define("Datie.view.loginView", {
extend: 'Ext.Container',
xtype: "login-view",
alias: "widget.loginview",
requires: [
      'Ext.form.FieldSet', 
      'Ext.form.Password', 
      'Ext.Label', 
      'Ext.Img'
      ],
config:{
        items: [

                    {

                        xtype: 'image',

                        src: Ext.Viewport.getOrientation() == 'portrait' ? '../Datie/resources/image/login.jpg' : '../Datie/resources/image/login.jpg',

                        style: Ext.Viewport.getOrientation() == 'portrait' ? 'width:80px;height:80px;margin:auto' : 'width:40px;height:40px;margin:auto'

                    },

                    {

                        xtype: 'label',

                        html: 'Login failed. Please enter the correct credentials.',

                        id: 'signInFailedLabel',

                        hidden: true,

                        hideAnimation: 'fadeOut',

                        showAnimation: 'fadeIn',

                        style: 'color:#990000;margin:5px 0px;'

                    },

                    {

                        xtype: 'fieldset',

                        items: [

                            {

                                xtype: 'textfield',

                                placeHolder: 'Username',

                                id: 'userNameTextField',

                                name: 'userNameTextField',

                                required: true

                            },

                            {

                                xtype: 'passwordfield',

                                placeHolder: 'Password',

                                id: 'passwordTextField',

                                name: 'passwordTextField',

                                required: true

                            }

                        ]

                    },

                    {

                        xtype: 'button',

                        id: 'logInBtn',

                        ui: 'action',

                        padding: '10px',

                        text: 'Log In'

                    }

         ]
    }
});