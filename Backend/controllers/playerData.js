const db = require("../db/db");

const dbName = "playerdata";

async function getAllPlayerData(req, res, next) {
  const connection = db.getConnection();

  try {
    const query = {};
    const fields = { projection: { _id: 0, playerTag: 1, highscore: 1 } };
    const sorting = { highscore: 1 };
    const data = await connection
      .collection(dbName)
      .find(query, fields)
      .sort(sorting)
      .toArray();
    if (!data) {
      res.status(400).send("PlayerData not found");
      return;
    }
    const items = { Items: data }; //Format benötigt für Unity
    res.status(200).send(items);
  } catch (err) {
    next(err);
  }
}

async function getPlayerData(req, res, next) {
  const connection = db.getConnection();

  try {
    const { playerTag } = req.params;
    const query = { playerTag };
    const fields = { projection: { _id: 0, playerTag: 1, highscore: 1 } };
    const data = await connection.collection(dbName).findOne(query, fields);
    if (!data) {
      res.status(400).send("PlayerData not found");
      return;
    }
    res.status(200).send(data);
  } catch (err) {
    next(err);
  }
}

async function updateHighscore(req, res, next) {
  const connection = db.getConnection();

  try {
    const { playerTag } = req.params;
    const highscore = parseInt(req.body.highscore);
    const query = { playerTag };
    const update = { $set: { highscore } };
    await connection.collection(dbName).updateOne(query, update);
    res.status(200).send(`PlayerData of ${playerTag} updated`);
  } catch (err) {
    next(err);
  }
}

module.exports = {
  getAllPlayerData,
  getPlayerData,
  updateHighscore,
};
