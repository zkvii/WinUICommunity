#pragma once

#include "InkControl.g.h"



namespace winrt::InkCanvasControl::implementation
{
    struct InkControl : InkControlT<InkControl>
    {
        InkControl()
        {
            // Xaml objects should not call InitializeComponent during construction.
            // See https://github.com/microsoft/cppwinrt/tree/master/nuget#initializecomponent
            InitializeComponent();
            CanvasTarget().CreateResources({ this, &InkControl::OnCreateResources });
            CanvasTarget().RegionsInvalidated({ this, &InkControl::OnRegionsInvalidated });


            CanvasTarget().PointerPressed({ this,&InkControl::OnPointerPressed });
            CanvasTarget().PointerMoved({ this,&InkControl::OnPointerMoved });
            CanvasTarget().PointerReleased({ this,&InkControl::OnPointerReleased });

        }

        bool m_isDrawing = false;
        
        POINT m_previousPoint;

        void OnPointerReleased(::winrt::Microsoft::Graphics::Canvas::UI::Xaml::CanvasVirtualControl const& sender, Windows::UI::Core::PointerEventArgs const& args)
        {
            m_isDrawing = false;
        }

        void OnPointerMoved(::winrt::Microsoft::Graphics::Canvas::UI::Xaml::CanvasVirtualControl const& sender, Windows::UI::Core::PointerEventArgs const& args)
        {
            if (m_isDrawing)
            {
                auto point = args.CurrentPoint().Position();
                m_previousPoint = point;
                CanvasTarget().Invalidate();
            }
        }

        void OnPointerPressed(::winrt::Microsoft::Graphics::Canvas::UI::Xaml::CanvasVirtualControl const& sender, Windows::UI::Core::PointerEventArgs const& args)
          {
              auto point = args.CurrentPoint();
              m_previousPoint = point;
              m_isDrawing = true;
          }


        void OnRegionsInvalidated(::winrt::Microsoft::Graphics::Canvas::UI::Xaml::CanvasVirtualControl const& sender, ::winrt::Microsoft::Graphics::Canvas::UI::Xaml::CanvasRegionsInvalidatedEventArgs const& args)
        {
            auto regions = args.InvalidatedRegions();
            for (auto region : regions)
            {
                auto drawSession=sender.CreateDrawingSession(region);
            
                drawSession.Clear(Microsoft::UI::Colors::AliceBlue());
                drawSession.DrawText(L"Hello, world!", 100, 100, Microsoft::UI::Colors::Colors::Black());

            
            }
        }
        
        void OnCreateResources(::winrt::Microsoft::Graphics::Canvas::UI::Xaml::CanvasVirtualControl const& sender, ::winrt::Microsoft::Graphics::Canvas::UI::CanvasCreateResourcesEventArgs const& args)
        {
        
        }

        // void myButton_Click(IInspectable const& sender, Microsoft::UI::Xaml::RoutedEventArgs const& args);
    };
}

namespace winrt::InkCanvasControl::factory_implementation
{
    struct InkControl : InkControlT<InkControl, implementation::InkControl>
    {
    };
}
