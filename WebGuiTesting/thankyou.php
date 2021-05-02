<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Dank u!</title>
</head>
<body>
<nav>
  <a href="index.html">Home</a>
  <a href="about.html">About</a>
  <a href="credits.html">Credits</a>
  <a href="contact.html">Contact</a>
</nav>

<section>
  <header>
    <h1>Dank u!</h1>
  </header>
  <article>
    <P>Dank u voor uw bericht</P>
    <div>
    <? echo $_POST['Naam']; ?>
    </div>
  </article>
</section>
<footer>
  <P>(c) 2021 Martin Molema / NHL Stenden </P>
</footer>

</body>
</html>
