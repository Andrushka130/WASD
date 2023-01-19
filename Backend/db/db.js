const { MongoClient } = require("mongodb");

const url = "mongodb://localhost:27017";
let connection;

async function connect(dbName) {
  const client = await MongoClient.connect(url, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  });

  connection = client.db(dbName);
  console.log(`connected to database ${dbName} ...`);
}

function getConnection() {
  return connection;
}

module.exports = {
  connect,
  getConnection,
};
