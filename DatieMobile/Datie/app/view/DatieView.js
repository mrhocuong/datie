Ext.define("Datie.view.DatieView", {
    extend: "Ext.tab.Panel",
    xtype: 'main',
    requires: [
        'Ext.TitleBar',
        'Ext.Container'
    ],
    config: {
        tabBarPosition: 'bottom',
        items: [
            {
                iconCls: 'home',
                styleHtmlContent: true,
                scrollable: true,
                items: [
                    {
                        xtype: 'toolbar',
                        docked: 'top',
                        ui: 'light',
                        items: [
                            {
                                xtype: 'button',
                                iconCls: 'more',
                                ui: 'light',
                                id: 'userBtn'
                            },
                            {
                                xtype: 'spacer'
                            },
                            {
                                xtype: 'container', html: "<img src='../Datie/resources/image/icon.png' width = '40px' height='40px'>"
                            },
                            {
                                xtype: 'spacer'
                            },
                            {
                                xtype: 'button',
                                iconCls: 'search',
                                ui: 'light',
                                id: 'searchBtn'
                            }
                        ]
                    },
                    {
                        
                    }
                ]
            },
            {
                iconCls: 'compose',
                items: [
                    {
                        xtype: 'toolbar',
                        ui: 'light',
                        items: [
                            {
                                xtype: 'spacer'
                            },
                            {
                                xtype: 'container', html: "<img src='../Datie/resources/image/icon.png' width = '40px' height='40px'>"
                            },
                            {
                                xtype: 'spacer'
                            }
                        ]
                    },
                    {
                        html: '<center>YOUR INFORMATION</center>'
                    },
                    {
                        html: '</br></br></br>-Area (District):<select id="districtList" onmousedown="if(this.options.length>3){this.size=3;}" onchange="this.size=0;" onblur="this.size=0;" style="position: absolute">\n\
                                                                   <option>District 1</option>\n\
                                                                   <option>District 2</option>\n\
                                                                   <option>District 3</option>\n\
                                                                   <option>District 4</option>\n\
                                                                   <option>District 5</option>\n\
                                                                   <option>District 6</option>\n\
                                                                   <option>District 7</option>\n\
                                                                   <option>District 8</option>\n\
                                                                   <option>District 9</option>\n\
                                                                   <option>District 10</option>\n\
                                                                   </select>'
                    },
                    {
                        html: '</br></br></br>-Money (VND):<input type="text" size="14" placeholder="Money(in number)">00,000'
                    },
                    {
                        html: [
                            "</br></br></br>",
                            "-Time: From: ",
                            "<select id='fromList' onmousedown='if(this.options.length>3){this.size=3;}' onchange='this.size=0;' onblur='this.size=0;' style='position: absolute'>",
                            "<option>01:00</option>",
                            "<option>02:00</option>",
                            "<option>03:00</option>",
                            "<option>04:00</option>",
                            "<option>05:00</option>",
                            "<option>06:00</option>",
                            "<option>07:00</option>",
                            "<option>08:00</option>",
                            "<option>09:00</option>",
                            "<option>10:00</option>",
                            "<option>11:00</option>",
                            "<option>12:00</option>",
                            "<option>13:00</option>",
                            "<option>14:00</option>",
                            "<option>15:00</option>",
                            "<option>16:00</option>",
                            "<option>17:00</option>",
                            "<option>18:00</option>",
                            "<option>19:00</option>",
                            "<option>20:00</option>",
                            "<option>21:00</option>",
                            "<option>22:00</option>",
                            "<option>23:00</option>",
                            "<option>24:00</option>",
                            "</select>",
                            "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp To: &nbsp",
                            "<select id='toList' onmousedown='if(this.options.length>3){this.size=3;}' onchange='this.size=0;' onblur='this.size=0;' style='position: absolute'>",
                            "<option>01:00</option>",
                            "<option>02:00</option>",
                            "<option>03:00</option>",
                            "<option>04:00</option>",
                            "<option>05:00</option>",
                            "<option>06:00</option>",
                            "<option>07:00</option>",
                            "<option>08:00</option>",
                            "<option>09:00</option>",
                            "<option>10:00</option>",
                            "<option>11:00</option>",
                            "<option>12:00</option>",
                            "<option>13:00</option>",
                            "<option>14:00</option>",
                            "<option>15:00</option>",
                            "<option>16:00</option>",
                            "<option>17:00</option>",
                            "<option>18:00</option>",
                            "<option>19:00</option>",
                            "<option>20:00</option>",
                            "<option>21:00</option>",
                            "<option>22:00</option>",
                            "<option>23:00</option>",
                            "<option>24:00</option>",
                            "</select>"
                        ].join("")
                    },
                    {
                        html: "</br></br></br></br></br>"
                    },
                    {
                        xtype: 'panel',
                        layout: 'hbox',
                        items: [
                            {
                                xtype: 'panel',
                                flex: 0.4
                            },
                            {
                                xtype: 'button',
                                ui: 'decline-round',
                                iconCls: 'delete',
                                width: '60px',
                                id: 'cancelBtn',
                                flex: 0.3
                            },
                            {
                                xtype: 'panel',
                                flex: 0.4
                            },
                            {
                                xtype: 'button',
                                ui: 'action-round',
                                width: '60px',
                                id: 'okBtn',
                                flex: 0.3,
                                iconCls: 'action'
                            },
                            {
                                xtype: 'panel',
                                flex: 0.4
                            }
                        ]
                    }
                ]
            },
            {
                iconCls: 'locate',
                items: [
                    {
                        xtype: 'toolbar',
                        ui: 'light',
                        items: [
                            {
                                xtype: 'spacer'
                            },
                            {
                                xtype: 'container', html: "<img src='../Datie/resources/image/icon.png' width = '40px' height='40px'>"
                            },
                            {
                                xtype: 'spacer'
                            }
                        ]
                    },
                    {
                        html: '<center>NEARBY PLACES</center>'
                    }
                ]
            }
        ]
    }

});
