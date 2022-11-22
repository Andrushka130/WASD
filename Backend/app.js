const { application } = require("express");
const express = require("express");
const {MongoClient} = require("mongodb");

const app = express();

app.use(express.urlencoded({ extended: true }));
app.use(express.json());

const PORT = 3000;
const routePD = "/playerdata";
const routeAC = "/account";
const dbName = "playerdata";
const paramPD = "/:playerTag";


let db = null;
const url = `mongodb://localhost:27017`;
MongoClient.connect(url, {
  useNewUrlParser: true,
  useUnifiedTopology: true,
}).then((connection) => {
  db = connection.db(dbName);
  console.log(`connected to database ${dbName} ...`);
});

app.use((req, res, next) => {
  console.log(`${new Date().toISOString()}: ${req.method} ${req.url}`);
  next();
});

app.route(routePD)
.get(async (req, res, next) => {
  try {
    const data = await db.collection(dbName).find().toArray();
    const item = {item: data}
    if(!data) {
      res.status(400).send("PlayerData not found");
      return;
    }
    res.status(200).send(item);
  } catch (err) {
    next(err);
  }
})
.post(async (req, res) => {
  try  {
    await db.collection(dbName).insertOne(req.body);
    console.log(`${req.body.playerTag} inserted ...`)
    res.status(201).send(`${req.body.playerTag} inserted ...`);
  } catch (err) {
    next(err);
  }
});

app.route(`${routePD}${paramPD}`)
.get(async (req, res, next) => {
  try{
    const {playerTag} = req.params;
    const data = await db.collection(dbName).findOne({playerTag});
    if(!data) {
      res.status(400).send("PlayerData not found");
      return;
    }
    res.status(200).send({playerTag: data.playerTag, highscore: data.highscore});
  } catch (err) {
    next(err);
  }
})
.put(async (req, res, next) => {
  try{
    const {playerTag} = req.params;
    const {highscore} = req.body;
    await db.collection(dbName).findOneAndUpdate({playerTag: `${playerTag}`}, {$set: {highscore: `${highscore}`}});
  } catch (err) {
    next(err);
  }
})
.patch(async (req, res, next) => {
  try{

  } catch (err) {
    next(err);
  }
})
.delete(async (req, res, next) => {
  try{

  } catch (err) {
    next(err);
  }
});


app.route(routeAC)
.get(async (req, res, next) => {
  try {
    const data = await db.collection(dbName).find().toArray();
    if(!data) {
      res.status(400).send("PlayerData not found");
      return;
    }
    res.status(200).send({data});
  } catch (err) {
    next(err);
  }
})
.post(async (req, res) => {
  try  {
    await db.collection(dbName).insertOne(req.body);
    console.log(`${req.body.playerTag} inserted ...`)
    res.status(201).send(`${req.body.playerTag} inserted ...`);
  } catch (err) {
    next(err);
  }
});

app.route(`${routeAC}${paramPD}`)
.get(async (req, res, next) => {
  try{

  } catch (err) {
    next(err);
  }
})
.put(async (req, res, next) => {
  try{

  } catch (err) {
    next(err);
  }
})
.patch(async (req, res, next) => {
  try{

  } catch (err) {
    next(err);
  }
})
.delete(async (req, res, next) => {
  try{

  } catch (err) {
    next(err);
  }
});

app.get("/create", async (req, res) => {
    await db.createCollection(dbName);
    res.send("Collection playerdata created ...");
});

// 404-Handler
app.use((req, res) => {
  res.status(404).send({ message: 'Not found' });
});

// Error-Middleware
app.use((err, req, res, next) => {
  res.status(500).send({ message: 'InternalServerError' });
  console.error(err);
});

app.listen(PORT);
console.log(`Server listening on port ${PORT}`);