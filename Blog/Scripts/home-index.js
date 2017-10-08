(function ($) {  
    function HomeIndex() {  
        var $this = this;  
  
        function initialize() {  
            $('#Text').summernote({  
                focus: true,  
                height: 200,    
                codemirror: {   
                    theme: 'united'  
                }  
            });  
        }  
  
        $this.init = function () {  
            initialize();  
        }  
    }  
    $(function () {  
        var self = new HomeIndex();  
        self.init();  
    })  
}(jQuery)) 