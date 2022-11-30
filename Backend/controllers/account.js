const db = require("../db/index");

const dbName = "playerdata";

async function getAccounts(req, res, next) {
  const connection = db.getConnection();

  try {
    const data = await connection.collection(dbName).find().toArray();
    if (!data) {
      res.status(400).send("Account could not be found");
      return;
    }

    const filter = data.map((o) => ({
      playerTag: o.playerTag,
      password: o.password,
      email: o.email,
    }));

    res.status(200).send({ Items: filter });
  } catch (err) {
    next(err);
  }
}

async function createAccount(req, res, next) {
  const connection = db.getConnection();

  try {
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
    const data = await connection.collection(dbName).findOne({ playerTag });
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
    if (data.hasOwnProperty("password")) {
      await connection.collection(dbName).findOneAndUpdate(
        { playerTag: `${playerTag}` },
        {
          $set: {
            password: `${data.password}`,
          },
        }
      );
    }
    if (data.hasOwnProperty("email")) {
      await connection.collection(dbName).findOneAndUpdate(
        { playerTag: `${playerTag}` },
        {
          $set: {
            email: `${data.email}`,
          },
        }
      );
    }
    if (data.hasOwnProperty("playerTag")) {
      await connection.collection(dbName).findOneAndUpdate(
        { playerTag: `${playerTag}` },
        {
          $set: {
            playerTag: `${data.playerTag}`,
          },
        }
      );
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
    await connection
      .collection(dbName)
      .findOneAndDelete({ playerTag: `${playerTag}` });
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
