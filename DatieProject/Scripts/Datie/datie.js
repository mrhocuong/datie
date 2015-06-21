$(document).ready(function() {
    $("#example").DataTable({
        "ajax": {
            "url": "Datie/GetData",
            "type": "POST",
            "dataType": "json",
            "data": "data",
        },
        "columns": [
                { "data": "ShopId" },
                { "data": "ShopName" },
                { "data": "ShopAddress" },
                { "data": "ShopPhone" },
                { "data": "ShopDescription" },
                { "data": "ShopTimeMid" },
                { "data": "ShopPriceMid" },
                { "data": "ShopRate" },
                { "data": "ShopIsDeleted" }
        ]
    });
});