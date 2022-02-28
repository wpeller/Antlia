CKEDITOR.plugins.add('Siga2ImagemExtender',
{
    init: function(editor) {
        editor.addCommand('incluirImagem',
        {
            exec: function(editor) {
                //var timestamp = new Date();
                //editor.insertHtml('The current date and time is: <em>' + timestamp.toString() + '</em>');
                //                var Eventtarget = $("[id*=Siga2ImagemExtender_btnMostarDivs]").attr("name");
                //                __doPostBack(Eventtarget, "");
                //var idEditor = CKEDITOR.currentInstance.name;

                //                var currentEditor;
                //                for (var id in CKEDITOR.instances) {
                //                    CKEDITOR.instances[id].on('focus', function(e) {
                //                        currentEditor = e.editor.name;
                //                    });
                //                }

                //                var ck_instance_name;
                //                for (var ck_instance in CKEDITOR.instances) {
                //                    if (CKEDITOR.instances[ck_instance].focusManager.hasFocus) {
                //                        ck_instance_name = ck_instance;
                //                    }
                //                }

                //                if (ck_instance_name != undefined) {
                //                    var retValue = showModalDialog("Siga2ImagemExtender.aspx?idEditor=" + ck_instance_name, "", "dialogWidth:700px; dialogHeight:500px;center:yes");
                //                    editor.insertHtml(retValue);
                //                }
                //                else {
                //                    alert("Marque a área do texto onde se deseja incluir a imagem !");
                //                }

                //                var ck_instance_name = CKEDITOR.currentInstance.name;
                //                if (ck_instance_name == undefined) {
                //                    alert("Posicione o cursor na area do texto onde se deseja incluir a imagem !");
                //                }
                //                else {
                //                    var Eventtarget = $("[id*=Siga2ImagemExtender_btnMostarDivs]").attr("name");
                //                    __doPostBack(Eventtarget, ck_instance_name);
                //                    $('[id*=Siga2ImagemExtender_Panel]').show();
                //                }
                     
                var ck_instance_name;
                try{
                
                    ck_instance_name = CKEDITOR.currentInstance.name;
                    
                     //Captura o id da instancia atual do editor
                    $('[id*=hdnCurrentEditorId]').val(ck_instance_name);

                    //Mostra a popup para cadastro/seleção da imagem
                    $('[id*=Siga2ImagemExtender_Panel]').show();
                }
                catch (err) {
                    $('[id*=Siga2ImagemExtender_lblPopUpMsg]').text("Posicione o cursor na area do texto onde se deseja incluir a imagem !");
                    $('[id*=Siga2ImagemExtender_pnlPopUpMsg]').show();
                    return false;
                }
                   

            }
        });
        editor.ui.addButton('Siga2ImagemExtender',
        {
            label: 'Incluir Imagem',
            command: 'incluirImagem',
            icon: this.path + 'image_icon_ckeditor.png'
        });
    }
});

