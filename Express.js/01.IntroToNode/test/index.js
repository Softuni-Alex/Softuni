const http = require('http')

let app = http.createServer((req, res) => {
    if (req.method === 'GET') {
        switch (req.url) {
            case '/about':
                res.write('About!');
                res.end()
                break;
            case '/':
                res.write('Home!');
                res.end()
                break;
        }
    }
});

let port = '5000';

app.listen(port)

console.log(`Server listening on port ${port}`)