const db = require("../db/db");

const dbName = "playerdata";

const DATA = [
  { playerTag: "PhoenixLex", password: "22#FXGQt", email: "zella_cruickshank71@gmail.com", highscore: 15, loggedIn: false},
  { playerTag: "ByteChilled", password: "qwWKIuGJ", email: "joaquin30@yahoo.com", highscore: 26, loggedIn: false},
  { playerTag: "Mud2hot", password: "5#QL-i0U", email: "vivienne_volkman30@yahoo.com", highscore: 13, loggedIn: false},
  { playerTag: "SilverCrunch", password: "+R3oVq1Z", email: "ashlynn_cronin64@gmail.com", highscore: 21, loggedIn: false},
  { playerTag: "GrantExpert", password: "aB-jtQGv", email: "joel_schimmel66@gmail.com", highscore: 34, loggedIn: false},
  { playerTag: "InvaderPhreek", password: "&0Amwpiy", email: "kendra86@hotmail.com", highscore: 17, loggedIn: false},
  { playerTag: "CistProdigy", password: "R%VStJ3Y", email: "adele.medhurst43@hotmail.com", highscore: 8, loggedIn: false},
  { playerTag: "ChilledNeo", password: "DSZ*9vjc", email: "nikko_brown85@hotmail.com", highscore: 27, loggedIn: false},
  { playerTag: "CrayonTweet", password: "Avj#iedF", email: "alberto.howell13@hotmail.com", highscore: 19, loggedIn: false},
  { playerTag: "PaperTips", password: "1zFUPk+2", email: "vincent.williamson44@yahoo.com", highscore: 11, loggedIn: false},
  { playerTag: "SincereJide", password: "o3bcDKpa", email: "kraig_wilkinson75@hotmail.com", highscore: 24, loggedIn: false},
  { playerTag: "ShmoeMiny", password: "6txcOVrH", email: "ignatius.lakin89@hotmail.com", highscore: 26, loggedIn: false},
  { playerTag: "FelineGirl", password: "tACO^+$O", email: "gideon32@hotmail.com", highscore: 14, loggedIn: false},
  { playerTag: "SkaterAlli", password: "&Nw#oxGK", email: "abel_rice@hotmail.com", highscore: 3, loggedIn: false},
  { playerTag: "UnlimitedSunny", password: "BLF*VZbD", email: "edwin.zieme97@hotmail.com", highscore: 32, loggedIn: false},
  { playerTag: "CapoLime", password: "ayQn*IdH", email: "lorna22@hotmail.com", highscore: 22, loggedIn: false},
  { playerTag: "FlirtyBull", password: "ZVzoCTkN", email: "alexa_carroll@hotmail.com", highscore: 28, loggedIn: false},
  { playerTag: "MasterGutsy", password: "hLN47^ny", email: "angelica_kovacek@yahoo.com", highscore: 30, loggedIn: false},
  { playerTag: "GlossyPuppy", password: "sf9WB8nC", email: "jaeden.turcotte@yahoo.com", highscore: 9, loggedIn: false},
  { playerTag: "MinyHulk", password: "&lDF7UnG", email: "imogene.will@yahoo.com", highscore: 18, loggedIn: false}
];

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
      projection: { _id: 0, password: 1 },
    };
    const data = await connection.collection(dbName).findOne(query, fields);
    if (!data) {
      res.status(400).send("Username not found!");
      return;
    }
    if (body.password != data.password) {
      res.status(400).send("Invalid password!");
      return;
    }
    res.status(200).send("true");
  } catch (err) {
    next(err);
  }
}

async function changeAccount(req, res, next) {
  const connection = db.getConnection();

  try {
    const {playerTag} = req.params;
    const newPlayerTag = req.body.playerTag;
    const { email, password } = req.body;
    const searchQuery = { $or: [{ playerTag: newPlayerTag } , { email }] };
    const updateQuery = { playerTag };
    const fields = { projection: { _id: 0, playerTag: 1, email: 1, password: 1} };
    const searchAccount = await connection.collection(dbName).findOne(searchQuery, fields);
    const updateAccount = await connection.collection(dbName).findOne(updateQuery, fields);

    if (searchAccount) {
      if (searchAccount.playerTag === newPlayerTag) {
        res.status(400).send("Player name already exists!");
        return;
      }
      if (searchAccount.email === email) {
        res.status(400).send("Email already exists!");
        return;
      }
    }

    if (password != "" && password != updateAccount.password) {
      const password = req.body.password;
      const update = { $set: { password } };
      await connection.collection(dbName).updateOne(updateQuery, update);
    }
    if (email != "" && email != updateAccount.email) {
      const email = req.body.email;
      const update = { $set: { email } };
      await connection.collection(dbName).updateOne(updateQuery, update);
    }
    if (newPlayerTag != "" && newPlayerTag != updateAccount.playerTag) {
      const update = { $set: { playerTag: newPlayerTag } };
      await connection.collection(dbName).updateOne(updateQuery, update);
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
    const remove = { playerTag };
    const account = await connection
      .collection(dbName)
      .findOneAndDelete(remove);
    if (!account.value) {
      res.status(400).send(`Account ${playerTag} doesnt exist!`);
      return;
    }
    res.status(200).send(`PlayerData of ${playerTag} deleted`);
  } catch (err) {
    next(err);
  }
}

async function insertTestData(req, res, next) {
  const connection = db.getConnection();

  try {
    await connection.collection(dbName).insertMany(DATA);
    res.status(201).send("Test data inserted ...");
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
  insertTestData
};
