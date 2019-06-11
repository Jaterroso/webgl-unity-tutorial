function onInit(){
    document.getElementById('flapImage').addEventListener('mousedown', function(){
        window.unityInstance.SendMessage("Bird", "DoFlap");
    });
}