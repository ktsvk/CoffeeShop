const sendmessbtn = document.querySelector('#sendmess');
if (sendmessbtn != null)
        sendmessbtn.addEventListener('click', () => {
        const sendmessform = document.querySelector('#sendmess_form');
        sendmessform.style = 'display: flex';
        sendmessbtn.style = 'display: none';
    });

//Manage
const change_info_input = document.querySelectorAll('.change_info_input');
const change_info_btn = document.querySelector('#change_info_btn');
const change_info_submit_btn = document.querySelector('#change_info_submit_btn');
change_info_btn.addEventListener('click', (e) => {
    for (let i = 0; i < change_info_input.length; i++) {
        change_info_input[i].style = 'display: inline';
    }
    change_info_submit_btn.style = 'display: inline';
    e.preventDefault();
});