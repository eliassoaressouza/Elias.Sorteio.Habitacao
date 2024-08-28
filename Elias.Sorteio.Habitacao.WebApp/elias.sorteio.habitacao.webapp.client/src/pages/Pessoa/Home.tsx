import { Pessoa } from "../../models/pessoa";
import { useEffect, useState } from 'react';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { PessoaLista } from "./PessoaLista";
import { useNavigate } from "react-router-dom";
export function Home() {

  const navigate = useNavigate();
  const [listaPessoas, setPessoas] = useState<Pessoa[]>();
  function realizarSorteioClick() {
    navigate("/sorteio");
  }

  async function obterLista() {
    const response = await fetch('pessoa');
    const data = await response.json();

    setPessoas(data);
  }


  useEffect(() => {
    obterLista();
  }, []);

  return (
    <>
      <div className="container">
        <div style={{ textAlign: 'center' }} >
          <h1>Sorteio de Habitação</h1>
          <h2>Lista dos Participantes do Sorteio</h2>
        </div>
        <div className="row">
          <div className="col-sm">
            <h2>Total de Participantes: {listaPessoas?.length}</h2>
          </div>
          <div className="col-sm">
            <button className="btn btn-primary"   onClick={realizarSorteioClick} >Realizar Sorteio</button>
          </div>
        </div>

        <ul className="nav nav-tabs" id="myTab" role="tablist">
          <li className="nav-item" role="presentation">
            <button className="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home-tab-pane" type="button" role="tab" aria-controls="home-tab-pane" aria-selected="true">
              IDOSOS</button>
          </li>
          <li className="nav-item" role="presentation">
            <button className="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile-tab-pane" type="button" role="tab" aria-controls="profile-tab-pane" aria-selected="false">
              DEFICIENTE FISICO</button>
          </li>
          <li className="nav-item" role="presentation">
            <button className="nav-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#contact-tab-pane" type="button" role="tab" aria-controls="contact-tab-pane" aria-selected="false">
              GERAL
            </button>
          </li>

        </ul>
        <div className="tab-content" id="myTabContent">
          <div className="tab-pane fade show active" id="home-tab-pane" role="tabpanel" aria-labelledby="home-tab" >
            <PessoaLista listaPessoa={listaPessoas ? listaPessoas.filter(p => p.cota == 'IDOSO') : []} />
          </div>
          <div className="tab-pane fade" id="profile-tab-pane" role="tabpanel" aria-labelledby="profile-tab" >

            <PessoaLista listaPessoa={listaPessoas ? listaPessoas.filter(p => p.cota == 'DEFICIENTE FÍSICO') : []} />
          </div>
          <div className="tab-pane fade" id="contact-tab-pane" role="tabpanel" aria-labelledby="contact-tab" >

            <PessoaLista listaPessoa={listaPessoas ? listaPessoas.filter(p => p.cota == 'GERAL') : []} />
          </div>

        </div>



      </div>
    </>
  );
}