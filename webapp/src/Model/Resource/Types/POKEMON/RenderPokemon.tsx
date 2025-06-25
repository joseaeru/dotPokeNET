import type { PokemonResponseDTO } from "./PokemonDTO";

type Props = {
  pokemonResponse: PokemonResponseDTO;
};

export default function RenderPokemon({ pokemonResponse: res }: Props) {
  return (

    //<pre>{JSON.stringify(data, null, 2)}</pre> // Uncomment this line to see the raw data

    <div className="col-lg-12" style={{ margin: 0, padding: "10px", border: "1px solid #ccc", borderRadius: "5px" }}>

      <div className="col-lg-12">
        <h3 className="uppercase">
          {res.name.toUpperCase()} <small className="text-muted">#{res.id}</small>
        </h3>
      </div>

      <div className="col-lg-3" style={{ margin: 0, padding: 0}}>
        <div className="col-lg-12">
          <img className="img img-responsive img-thumbnail" style={{ height: "200px", display: "block", margin: "auto" }}
            src={res.sprites?.other?.["official-artwork"]?.front_default ?? undefined} />

          <div className="carousel-container">
            <div id="myCarousel" className="carousel slide" data-ride="carousel">

              <div className="carousel-inner">
                <div className="item active">
                  <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                    src={res.sprites?.front_default ?? undefined} />
                </div>
                {res.sprites?.back_default ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.back_default} />
                  </div> : ""}
                {res.sprites?.front_female ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.front_female} />
                  </div> : ""
                }
                {res.sprites?.back_female ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.back_female} />
                  </div> : ""}
                {res.sprites?.front_shiny ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.front_shiny} />
                  </div> : ""}
                {res.sprites?.back_shiny ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.back_shiny} />
                  </div> : ""}
                {res.sprites?.front_shiny_female ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.front_shiny_female} />
                  </div> : ""}
                {res.sprites?.back_shiny_female ?
                  <div className="item">
                    <img className="img img-responsive" style={{ display: "block", margin: "auto" }}
                      src={res.sprites?.back_shiny_female} />
                  </div> : ""}
              </div>

              <a className="left carousel-control"
                href="#myCarousel" data-slide="prev">
                <span className="glyphicon glyphicon-chevron-left"></span>
              </a>
              <a className="right carousel-control" href="#myCarousel" data-slide="next">
                <span className="glyphicon glyphicon-chevron-right"></span>
              </a>
            </div>
          </div>
        </div>
      </div>

      <div className="col-lg-3" style={{ margin: 0, padding: 0}}>
        <div className="col-lg-12">
          <strong>Types:</strong>
          <ul className="">
            {
              res.types?.map(t => (
                <li>
                  <p>
                    <a href={t.type.url}>{t.type.name}</a>
                  </p>
                </li>
              ))
            }
          </ul>
        </div>

        <div className="col-lg-12">
          <strong>Height:</strong> {res.height}
        </div>

        <div className="col-lg-12">
          <strong>Weight:</strong> {res.weight}
        </div>

        <div className="col-lg-12">
          <strong>Stats:</strong>
          <ul className="">
            {
              res.stats?.map(t => (
                <li>
                  <p>
                    <a href={t.stat.url}>{t.stat.name}</a>
                    &nbsp;:&nbsp;{t.base_stat}
                  </p>
                </li>
              ))
            }
          </ul>
        </div>

        <div className="col-lg-12">
          <strong>Base Experience:</strong> {res.base_experience}
        </div>

      </div>

      <div className="col-lg-3" style={{ margin: 0, padding: 0}}>
        <strong>Habilities:</strong>
        <ul className="list-disc ml-5">
          {res.abilities.map((a: { ability: { name: string } | null; is_hidden: boolean }) => (
            <li key={a.ability?.name || "unknown"}>
              {a.ability?.name || "Unknown Ability"} {a.is_hidden ? "(hidden)" : ""}
            </li>
          ))}
        </ul>
      </div>

      <div className="col-lg-3" style={{ margin: 0, padding: 0}}>
        <strong>Movements:</strong>
        <div className="col-lg-12" style={{ maxHeight: "50vh", overflowY: "auto" }}>
          <ul className="list-disc ml-5">
            {res.moves.map((m: { move: { name: string } }) => (
              <li key={m.move.name}>
                {m.move.name}
              </li>
            ))}
          </ul>
        </div>
      </div>

    </div>
  );
}