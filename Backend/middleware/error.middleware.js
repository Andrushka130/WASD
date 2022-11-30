function handleServerErrors(err, req, res, next) {
  res.status(500).send({ message: "InternalServerError" });
  console.error(err);
}

function handleNotFoundErrors(req, res) {
  res.status(404).send({ message: 'Not found' });
}

module.exports = {
  handleServerErrors,
  handleNotFoundErrors
};
