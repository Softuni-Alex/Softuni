let fs = require('fs')
let url = require('url')

module.exports =(req,res) => {
req.pathName = req.pathName || url.parse(req.url).pathname

    if (req.pathName === '/favicon.ico') {
     fs.readFile('./content/favicon.ico', (err,data) =>{
     if(err){
       console.log(err)
     }
     res.writeHead(200)
     res.write(data)
     res.end()
   })
  } else{
    return true
  }
}
