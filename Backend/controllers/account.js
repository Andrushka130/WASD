const db = require("../db/db");

const dbName = "playerdata";

async function getAccounts(req, res, next) {
  const connection = db.getConnection();

  try {
    const query = {};
    const fields = {
      projection: { _id: 0, playerTag: 1, password: 1, email: 1 },
    };
    const data = await connection
      .collection(dbName)
      .find(query, fields)
      .toArray();
    if (!data) {
      res.status(400).send("Account could not be found");
      return;
    }

    const items = { Items: data };
    res.status(200).send(items);
  } catch (err) {
    next(err);
  }
}

async function createAccount(req, res, next) {
  const connection = db.getConnection();

  try {
    const { playerTag, email } = req.body;
    const query = { $or: [{ playerTag }, { email }] };
    const fields = { projection: { _id: 0, playerTag: 1, email: 1 } };
    const account = await connection.collection(dbName).findOne(query, fields);
    if (account) {
      if (account.playerTag === playerTag) {
        res.status(400).send("Player name already exists!");
        return;
      }
      if (account.email === email) {
        res.status(400).send("Email already exists!");
        return;
      }
    }
    await connection.collection(dbName).insertOne(req.body);
    res.status(201).send(`${req.body.playerTag} inserted ...`);
  } catch (err) {
    next(err);
  }
}

async function login(req, res, next) {
  const connection = db.getConnection();

  try {
    const { playerTag } = req.params;
    const body = req.body;
    const query = { playerTag };
    const fields = {
      projection: { _id: 0, playerTag: 0, email: 0, highscore: 0 },
    };
    const data = await connection.collection(dbName).findOne(query, fields);
    if (
      !data ||
      (data.playerTag === playerTag && !(body.password === data.password))
    ) {
      res.status(400).send("Account not found or invalid password");
      return;
    }
    res.status(200).send("true");
    return;
  } catch (err) {
    next(err);
  }
}

async function changeAccount(req, res, next) {
  const connection = db.getConnection();

  try {
    const { playerTag } = req.params;
    const data = req.body;
    const query = { playerTag };

    if (data.hasOwnProperty("password")) {
      const password = req.body.password;
      const update = { $set: { password } };
      await connection.collection(dbName).updateOne(query, update);
    }
    if (data.hasOwnProperty("email")) {
      const email = req.body.email;
      const update = { $set: { email } };
      await connection.collection(dbName).updateOne(query, update);
    }
    if (data.hasOwnProperty("playerTag")) {
      const newPlayerTag = req.body.playerTag;
      const update = { $set: { newPlayerTag } };
      await connection.collection(dbName).updateOne(query, update);
    }

    res.status(200).send(`PlayerData of ${playerTag} updated`);
  } catch (err) {
    next(err);
  }
}

async function deleteAccount(req, res, next) {
  const connection = db.getConnection();

  try {
    const { playerTag } = req.params;
    const remove = {playerTag};
    const account = await connection
      .collection(dbName)
      .findOneAndDelete(remove);
    if(!account.value){
      res.status(400).send(`Account ${playerTag} doesnt exist!`);
      return;
    }
    res.status(200).send(`PlayerData of ${playerTag} deleted`);
  } catch (err) {
    next(err);
  }
}

module.exports = {
  getAccounts,
  createAccount,
  login,
  changeAccount,
  deleteAccount,
};
