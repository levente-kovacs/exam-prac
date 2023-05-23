/*function GenerateSalt()
{
    let salt=""
    let possible="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
    for (let i=0;i<64;i++)
    {
        salt+=possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return salt
}*/

let password="a";
let salt=GenerateSalt();
//salt="XDNRw5XBEGBXDBmBktxeYlzOG7emYhghbpnJLqv75kf4bPeE8v7wQCgvN9Kybvnh"
let hash=CryptoJS.SHA256(CryptoJS.SHA256(password+salt).toString()).toString();
console.log(password);
console.log(salt);
console.log(hash);