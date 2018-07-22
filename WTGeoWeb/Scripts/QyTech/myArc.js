var ArcMap;
require([
    "esri/map",
    "esri/layers/ArcGISDynamicMapServiceLayer",
    "esri/dijit/OverviewMap",
    "dojo/parser","dojo/dom",
    "dijit/layout/BorderContainer",
    "dijit/layout/ContentPane",//??

    "esri/tasks/FindTask",
    "esri/tasks/FindParameters",

    
    "esri/tasks/query",
    "esri/tasks/IdentifyTask",
    "esri/tasks/IdentifyParameters",
    "esri/toolbars/draw",
    "esri/symbols/SimpleFillSymbol",
    "esri/symbols/SimpleLineSymbol",
    "esri/graphic",
    "dojo/colors",

    "dojo/domReady!"
    ],
    function(Map,ArcGISDynamicMapServiceLayer,OverviewMap,parser
        ,on
        ,dom
        ,IdentifyTask,IdentifyParameters
        ,draw,SimpleFillSymbol,SimpleLineSymbol,Graphic,Color
    ){
        //parser.parse();
        function mapClick(e){
            //获得用户点击的地图坐标
            var point=e.mapPoint;
            
            //实例化查询参数
            var query=new  esri.tasks.Query();
            query.geometry = point;
            query.outFields = ["*"];
            query.outSpatialReference = map.spatialReference;
            query.spatialRelationship =  esri.tasks.Query.SPATIAL_REL_INTERSECTS;
            query.returnGeometry = true;
            //实例化查询对象
            var queryTask = new esri.tasks.QueryTask("http://122.114.38.213/arcgis/rest/services/WTMap/TD_SpatialServerTest/MapServer/0");
            //进行查询                                
            queryTask.execute(query,showFindResult)
            
        };
        function showFindResult(queryResult)
        {
            // console.log(queryResult);
            // if (queryResult.features == 0) {
            // 	alert("没有该元素");
            // 	return;
            // }
            for (var i = 0; i < queryResult.features.length; i++) {
                //获得该图形的形状
                var feature = queryResult.features[i];
                var geometry = feature.geometry;
                console.log(geometry);
                var ptName = feature.attributes["OBJECTID"];
                alert(ptName);
                //定义高亮图形的符号
                //1.定义面的边界线符号
                var outline= new SimpleLineSymbol(SimpleLineSymbol.STYLE_DASHDOT,new Color([255, 0, 0]), 3);
                //2.定义面符号                     
                //var PolygonSymbol = new SimpleFillSymbol(SimpleFillSymbol.STYLE_SOLID, outline,new dojo.colors.Color([0, 255, 0, 1]));
                //创建客户端图形
                //var graphic = new Graphic(geometry, PolygonSymbol);
                //将客户端图形添加到map中
                //map.graphics.add(graphic);
            }
        };

        setLayers = function(vis){
            layer.setVisibleLayers(vis);
        };
    });







ArcMap = function (divid) {
    this.isClustered = false;//后面会加入聚合功能
    this.map = new Map(divid, {
        slider: false
    });
    this.commonGraphicsLayer = new GraphicsLayer({
        id: "commonGraphicsLayer"
    });//通用的绘图图层
 
    var MapServer = "http://122.114.38.213/arcgis/rest/services/WTMap/TD_SpatialServerTest/MapServer";
    var layer=new ArcGISDynamicMapServiceLayer(MapServer);
    map.addLayer(layer);
    map.on("click",mapClick);
        
        

    this.map.centerAndZoom(new Point(120.263391, 31.486093), 12);
};


<script src="js/result.js"></script>
	