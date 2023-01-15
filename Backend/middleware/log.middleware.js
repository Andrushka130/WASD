function logRequests(req, res, next) {
    console.log(`${new Date()}: ${req.method} ${req.url}`);
    next();
}

module.exports = {
    logRequests
}