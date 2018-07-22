/*村界查询结果*/
var vm = new Vue({
    el: "#app",
    data: {
        LayerName: '',
        totalLayers: [],
        totalTypes: [],
        details: []
    },
    mounted: function() {
        this.$nextTick(function() {
            this.resultView();
        });
    },
    methods: {
        resultView: function() {
            var _this = this;
            this.$http.get("data/result.json").then(function(res) {
                _this.LayerName = res.body.LayerName;
                _this.totalLayers = res.body.totalLayers;
                _this.totalTypes = res.body.totalLayers.totalTypes;

            });
        },
        getDetail: function() {
        	var rCode = $("input[name='regionCodes']").val();
        	var tName = $("input[name='TotalTypeName']").val();
        	$.post('http://122.114.38.213/Wjkfq_Gis/ShowView/GetTypeDetails', {
        	    regionCodes: rCode,
        	    typename: tName
        	},
        	function(data) {
        	    var details = [];
        	    if (data.length > 0) {
        	        vm.details = data;
        	        console.log(vm.details);
        	    } else {
        	        alert("暂无数据！");
        	    }
        	});
        	$('.ruralArea').hide();
        	$('.detail').show();
        },
        back: function() {
        	$('.detail').hide();
        	$('.ruralArea').show();

        }
    }
})
/*明细请求*/
// $(function(){
// $(".dBtn").click(function() {
//     var rCode = $("input[name='regionCodes']").val();
//     var tName = $("input[name='TotalTypeName']").val();
//     $.post('http://122.114.38.213/Wjkfq_Gis/ShowView/GetTypeDetails', {
//         regionCodes: rCode,
//         typename: tName
//     },
//     function(data) {
//         var details = [];
//         if (data.length > 0) {
//             vm.details = data;
//             console.log(vm.details);
//         } else {
//             alert("暂无数据！");
//         }
//     });
//     $('.ruralArea').hide();
//     $('.detail').show();
// });
// });