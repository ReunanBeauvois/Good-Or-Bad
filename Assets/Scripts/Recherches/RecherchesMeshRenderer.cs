using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recherches
{
    public class RecherchesMeshRenderer
    {
        public void BouclesRecherches(GameObject objet, List<MeshRenderer> meshRenderers, float transparence)
        {
            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers))
                    { meshRenderers.Add(_meshRenderers); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers2))
                            { meshRenderers.Add(_meshRenderers2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers3))
                                    { meshRenderers.Add(_meshRenderers3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers4))
                                            { meshRenderers.Add(_meshRenderers4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers5))
                                                    { meshRenderers.Add(_meshRenderers5); }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (meshRenderers.Count > 0)
            {
                for (int i = 0; i < meshRenderers.Count; ++i)
                {
                    var color = meshRenderers[i].materials[0].color;
                    color.a = transparence;
                    meshRenderers[i].materials[0].color = color;
                }
            }
        }

        public void BouclesRecherchesSansInfluencerLaTransparence(GameObject objet, List<MeshRenderer> meshRenderers)
        {
            if (objet.transform.childCount > 0)
            {
                for (int i = 0; i < objet.transform.childCount; ++i)
                {
                    if (objet.transform.GetChild(i).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers))
                    { meshRenderers.Add(_meshRenderers); }

                    if (objet.transform.GetChild(i).transform.childCount > 0)
                    {
                        for (int j = 0; j < objet.transform.GetChild(i).transform.childCount; ++j)
                        {
                            if (objet.transform.GetChild(i).transform.GetChild(j).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers2))
                            { meshRenderers.Add(_meshRenderers2); }

                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.childCount > 0)
                            {
                                for (int k = 0; k < objet.transform.GetChild(i).transform.GetChild(j).transform.childCount; ++k)
                                {
                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers3))
                                    { meshRenderers.Add(_meshRenderers3); }

                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount > 0)
                                    {
                                        for (int l = 0; l < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.childCount; ++l)
                                        {
                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers4))
                                            { meshRenderers.Add(_meshRenderers4); }

                                            if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount > 0)
                                            {
                                                for (int m = 0; m < objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.childCount; ++m)
                                                {
                                                    if (objet.transform.GetChild(i).transform.GetChild(j).transform.GetChild(k).transform.GetChild(l).transform.GetChild(m).TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderers5))
                                                    { meshRenderers.Add(_meshRenderers5); }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ReglageTransparenceMeshRendererNiveaux(List<MeshRenderer> meshRenderers, float transparence)
        {
            if (meshRenderers.Count > 0)
            {
                for (int i = 0; i < meshRenderers.Count; ++i)
                {
                    var color = meshRenderers[i].materials[0].color;

                    color.a += transparence;

                    meshRenderers[i].materials[0].color = color;
                }
            }
        }
    }
}